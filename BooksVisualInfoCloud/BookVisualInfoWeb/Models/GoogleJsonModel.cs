using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackFive.BookVisualInfoWeb.Models
{
	/// <summary>
	/// A class that represents the root node google uses for serializing book search results.
	/// </summary>
	public class GoogleJsonModel
	{
		public long totalItems { get; set; }
		//public GoogleBooksModel[] items { get; set; }
		public GoogleBooksModel[] items { get; set; }

		public GoogleJsonModel()
		{
			items = new GoogleBooksModel[0];
		}
	}
}