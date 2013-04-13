using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using HackFive.BookVisualInfoWeb.Models;

namespace HackFive.BookVisualInfoWeb.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
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
			var book = new BookModel();
			return Json(book, JsonRequestBehavior.AllowGet);
		}

		[HttpGet]
		public JsonResult GetFilters()
		{
			var filters = new List<BaseFilterModel>();
			return Json(filters, JsonRequestBehavior.AllowGet);
		}
	}
}
