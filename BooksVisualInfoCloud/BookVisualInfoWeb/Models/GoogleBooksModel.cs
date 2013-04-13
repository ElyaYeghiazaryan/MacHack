using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackFive.BookVisualInfoWeb.Models
{
	public class GoogleBooksModel
	{
		public VolumeInfo volumeInfo { get; set; }
		/*
		public string Title { get { return volumeInfo.title; } }
		public List<string> Authors { get { return volumeInfo.authors; } }
		public string PublishedDate { get { return volumeInfo.publishedDate; } }
		public string Genre { get { return volumeInfo.categories; } }*/
		
	}
	public class VolumeInfo
	{
		public string title { get; set; }
		public List<string> authors { get; set;}
		public string publishedDate { get; set;}
		public string categories { get; set;}
	}
}