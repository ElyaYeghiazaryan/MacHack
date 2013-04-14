using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackFive.BookVisualInfoWeb.Models
{
	/// <summary>
	/// A class used to simplify deserializing the json google produces for the books.
	/// </summary>
	public class GoogleBooksModel
	{
		public string id { get; set; }
		public VolumeInfo volumeInfo { get; set; }
		public float? averageRating { get; set; }

		
		public string Title { get { return volumeInfo.title; } }
		public string[] Authors { get { return volumeInfo.authors; } }
		public string PublishedDate { get { return volumeInfo.publishedDate; } }
		public string[] Genres { get { return volumeInfo.categories; } }
		
	}
	public class VolumeInfo
	{
		public string title { get; set; }
		public string[] authors { get; set;}
		public string publishedDate { get; set;}
		public string[] categories { get; set;}
	}
}