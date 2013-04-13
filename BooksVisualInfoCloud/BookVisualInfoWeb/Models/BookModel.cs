using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackFive.BookVisualInfoWeb.Models
{
	/// <summary>
	/// Represents a book in the google books 
	/// </summary>
	public class BookModel
	{
		public string Title { get; set; }
		public string Genre { get; set; }
		public GenreTypesEnum GenreType { get; set; }
		public string Author { get; set; }
		public float AvgRating { get; set; }

		//TODO - Move this, consider doing this differently.  This is going to make the size of the JSON unreasonably huge
		public string Description { get; set; }		
	}
}
