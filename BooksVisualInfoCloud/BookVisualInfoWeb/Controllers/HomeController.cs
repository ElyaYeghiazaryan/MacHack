using System.Net;
using System.Collections.Generic;
using System.Web.Mvc;
using HackFive.BookVisualInfoWeb.Models;
using System.IO;
using System;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace HackFive.BookVisualInfoWeb.Controllers
{
	public class HomeController : Controller
	{
		private const string API_KEY = "AIzaSyAgvKGw_prPT31SbPrx0SsPwnVsOsbBzdw";

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
		private string GetBooksFromGoogle(FilterCriteria criteria)
		{
			const string googleUriBaseString = @"https://www.googleapis.com/books/v1/volumes?q={1}&key={0}&fields=totalItems,items(volumeInfo(title,authors,publishedDate,categories))";

			string googleUri = String.Format(googleUriBaseString, API_KEY, BuildSearchString(criteria));

			string googJson = MakeGetRequest(googleUri);
			JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();

			//var jsonResult = (GoogleJsonModel)jsonSerializer.DeserializeObject(googJson);
			var jsonResult = JsonConvert.DeserializeObject<GoogleJsonModel>(googJson);

			return googJson;
		}

		private string BuildSearchString(FilterCriteria criteria)
		{
			const string TEST_INPUT = "flowers+inauthor:keyes";
			return TEST_INPUT;
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
