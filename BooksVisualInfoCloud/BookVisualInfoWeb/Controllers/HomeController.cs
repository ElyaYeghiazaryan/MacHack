using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using HackFive.BookVisualInfoWeb.Models;
using Newtonsoft.Json;
using System.Text;

namespace HackFive.BookVisualInfoWeb.Controllers
{
	public class HomeController : Controller
	{
		public const long MAX_BOOK_COUNT = 200;		//Divisible by 40 to minimize service request overhead and loss.

		#region "Authentication constants"
		private const string API_KEY = "AIzaSyAgvKGw_prPT31SbPrx0SsPwnVsOsbBzdw";
		private const string UID = "101555039325212133703";		//User id to populate default books and favourites
		#endregion

		#region "Google Search API Terms"
		private const string SF_TITLE_QUERY = "intitle:{0}";
		private const string SF_AUTHOR_QUERY = ",inauthor:{0}";
		private const string SF_CATEGORY_QUERY = ",subject:{0}";
		private const string SF_PUBLISHER_QUERY = "inpublisher:{0}";
		#endregion

		private bool CustomFilterFlag { get; set; }
		private float CustomMinFilterValue { get; set;}
		private string FilterString { get; set; }

		public ActionResult Index()
		{
			//GetBooksFromGoogle(null);
			return View();
		}
		
		[HttpGet]
		public JsonResult GetAllBooks()
		{
			return Json(GetBooksFromGoogle(null), JsonRequestBehavior.AllowGet);
		}


		[HttpGet]
		public JsonResult GetBooks(FilterCriteria criteria)
		{
			var bookList = new List<BookModel>();	// No need to actually properly cast this as it's being returned as a json result.
			if (criteria == null)
			{
				return Json(GetBooksFromGoogle(criteria), JsonRequestBehavior.AllowGet);
			}
			return Json(bookList, JsonRequestBehavior.AllowGet);
		}

		[HttpGet]
		public JsonResult GetBookData(FilterCriteria criteria)
		{
			//var book = new BookModel();
			return Json(GetBooksFromGoogle(criteria), JsonRequestBehavior.AllowGet);
		}
		[HttpGet]
		public JsonResult GetFilters()
		{
			var enumValues = Enum.GetValues(typeof(FilterTypesEnum));
			List<string> enumValueNames = new List<string>();

			foreach (var value in enumValues)
			{
				enumValueNames.Add(((FilterTypesEnum)value).ToString());
			}
			return Json(enumValueNames, JsonRequestBehavior.AllowGet);
		}

		[HttpGet]
		public JsonResult GetGenres()
		{
			var enumValues = Enum.GetValues(typeof(GenreTypesEnum));
			List<string> enumValueNames = new List<string>();

			foreach (var value in enumValues)
			{
				enumValueNames.Add(((GenreTypesEnum)value).ToString());
			}
			return Json(enumValueNames, JsonRequestBehavior.AllowGet);
		}


		//private List<BookModel> GetBooksFromGoogle(FilterCriteria criteria)
		private List<BookModel> GetBooksFromGoogle(FilterCriteria criteria)
		{
			var books = new List<BookModel>();
			GoogleJsonModel jsonResult;
			List<float> ratings = new List<float>();
			long count = 0;
			do
			{
				string googJson = GetGoogleJson(criteria, count);

				//TODO: There seems to a be a bug with the deserializer not pulling the averageRating.  I don't know why
				jsonResult = JsonConvert.DeserializeObject<GoogleJsonModel>(GetGoogleJson(criteria, count));
				foreach (var result in jsonResult.items)
				{
					if (result.Title == null) continue;		//Yes, This happened.

					var newBook = new BookModel
					{
						Id = result.id,
						Title = result.Title,
					};
					float averageRating = 0;
					
					string author = "Unknown";
					if (result.averageRating != null) 
						ratings.Add((float)result.averageRating);

					if (result.Authors != null) author = result.Authors.Length > 0 ? String.Join(",", result.Authors) : result.Authors[0];
					if (result.averageRating != null) averageRating = (float)result.averageRating;

					if (result.Genres != null && result.Genres.Length > 0)
					{
						newBook.GenreType = getFirstGenre(result.Genres);
						newBook.Genre = String.Join(",", result.Genres);
					}
					newBook.Author = author;
					newBook.AvgRating = averageRating;

					books.Add(newBook);
				}
				count += jsonResult.items.Length;

			//Differentiation between books.Count and count is on purpose.
			} while (jsonResult != null && count < jsonResult.totalItems && books.Count < MAX_BOOK_COUNT);

			return books;
		}

		private GenreTypesEnum getFirstGenre(string[] genres)
		{
			GenreTypesEnum firstGenre = GenreTypesEnum.Others;
			foreach (var genre in genres)
			{
				if (Enum.TryParse<GenreTypesEnum>(genre, out firstGenre))
					break;
			}

			return firstGenre;
		}

		/// <summary>
		/// based off criteria will generate a filter string to return appropriate books.  If it's been run previously it will 
		/// apply the FilterString generated last time.  
		/// </summary>
		private string GetGoogleJson(FilterCriteria criteria, long startIndex = 0)
		{
			const string googleUriBaseString =
				@"https://www.googleapis.com/books/v1/volumes?q={2}&key={0}&fields=totalItems," +
				@"items(id,volumeInfo(title,averageRating,authors,publishedDate,categories))&startIndex={1}&maxResults=40";	//&orderBy=newest";
			const string NULL_INPUT_CASE = "inpublisher:Houghton Mifflin Harcourt";

			if (criteria == null || criteria.filters.Count == 0)
				return MakeGetRequest(String.Format(googleUriBaseString, API_KEY, startIndex, NULL_INPUT_CASE));
			if(!String.IsNullOrWhiteSpace(FilterString))
				return MakeGetRequest(String.Format(googleUriBaseString, API_KEY, startIndex, FilterString));


			string title, categories, authors;
			title = categories = authors = "";
			float minAvgRating = 0;
			
			foreach (var filter in criteria.filters)
			{
				if(filter.FilterTypes == FilterTypesEnum.Genre)
				{
					if(String.IsNullOrWhiteSpace(categories))
						categories = filter.FilterValue;
					else
						categories += "," + filter.FilterValue;
				}
				else if(filter.FilterTypes == FilterTypesEnum.Author)
				{
					if(String.IsNullOrWhiteSpace(authors))
						authors = filter.FilterValue;
					else
						authors = "," + filter.FilterValue;
				}
				else if (filter.FilterTypes == FilterTypesEnum.MinAvgRating)
				{
					CustomFilterFlag = true;
					CustomMinFilterValue = float.Parse(filter.FilterValue);
				}
				else if (filter.FilterTypes == FilterTypesEnum.Title)
				{
					if (string.IsNullOrWhiteSpace(title))
						title = filter.FilterValue;
					else
						title = "," + filter.FilterValue;
				}
			}
			string queryString = "";
			if(title != null)
				queryString = String.Format(SF_TITLE_QUERY, title);
			if (authors != null)
				queryString = String.Format(SF_AUTHOR_QUERY, authors);
			if (categories != null)
				queryString = String.Format(SF_CATEGORY_QUERY, categories);

			queryString = queryString.TrimStart(',');
			FilterString = queryString;

			return MakeGetRequest(String.Format(googleUriBaseString, API_KEY, startIndex, FilterString));
		}
		
		public string MakeGetRequest(string uri)
		{
			var request = (HttpWebRequest)WebRequest.Create(uri);
			request.Method = HttpVerbs.Get.ToString();
			request.ContentLength = 0;
			request.ContentType = "application/json";

			string responseValue = string.Empty;

			using (var response = (HttpWebResponse)request.GetResponse())
			{
				if (response.StatusCode != HttpStatusCode.OK)
				{
					var message = String.Format("Goog Request failed. Received Response {0}", response.StatusCode);
					throw new ApplicationException(message);
				}

				using (var responseStream = response.GetResponseStream())
				{
					if (responseStream != null)
					{
						using (var reader = new StreamReader(responseStream))
						{
							responseValue = reader.ReadToEnd();
						}
					}
				}
			}

			return responseValue;
		}
	}
}
