using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using HackFive.BookVisualInfoWeb.Models;
using Newtonsoft.Json;

namespace HackFive.BookVisualInfoWeb.Controllers
{
	public class HomeController : Controller
	{
		private const string API_KEY = "AIzaSyAgvKGw_prPT31SbPrx0SsPwnVsOsbBzdw";
		private const long MAX_BOOK_COUNT = 150;

		public ActionResult Index()
		{
			GetBooksFromGoogle(null);
			return View();
		}
		[HttpGet]
		public JsonResult GetBooks(FilterCriteria criteria)
		{
			var bookList = new List<BookModel>();	// No need to actually properly cast this as it's being returned as a json result.

			if (criteria == null)
			{ 
				
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
			var filters = new List<BaseFilterModel>();
			return Json(filters, JsonRequestBehavior.AllowGet);
		}

		//private List<BookModel> GetBooksFromGoogle(FilterCriteria criteria)
		private List<BookModel> GetBooksFromGoogle(FilterCriteria criteria)
		{
			var books = new List<BookModel>();
			GoogleJsonModel jsonResult;
			long count = 0;
			do
			{
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
					GenreTypesEnum genreType = GenreTypesEnum.All;
					string author = "Unknown";

					if (result.Authors != null) author = result.Authors.Length > 0 ? String.Join(",", result.Authors) : result.Authors[0];
					if (result.averageRating != null)	float.TryParse(result.averageRating, out averageRating);
					if (result.Genres != null && result.Genres.Length > 0)	Enum.TryParse<GenreTypesEnum>(result.Genres[0], out genreType);

					books.Add(newBook);
				}
				count += jsonResult.items.Length;

			} while (jsonResult != null && count < jsonResult.totalItems && count < MAX_BOOK_COUNT);

			return books;
		}

		private string GetGoogleJson(FilterCriteria criteria, long startIndex = 0)
		{
			const string googleUriBaseString = 
				@"https://www.googleapis.com/books/v1/volumes?q={2}&key={0}&fields=totalItems," +
				@"items(id,volumeInfo(title,averageRating,authors,publishedDate,categories))&startIndex={1}&maxResults=40";
			
			//TODO add logic for search criteria.
			const string TEST_INPUT = "flowers+inauthor:keyes";

			return MakeGetRequest(String.Format(googleUriBaseString, API_KEY, startIndex, TEST_INPUT));
			
			
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
