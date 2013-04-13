using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackFive.BookVisualInfoWeb.Models
{
	public class GoogleJsonModel
	{
		public long totalItems { get; set; }
		public GoogleBooksModel[] items { get; set; }

		public GoogleJsonModel()
		{
			items = new GoogleBooksModel[0];
		}
	}
}