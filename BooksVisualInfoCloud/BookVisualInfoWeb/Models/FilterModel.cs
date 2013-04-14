using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackFive.BookVisualInfoWeb.Models
{
	public class BaseFilterModel
	{
		public string ImagePath { get; set; }
		public string FilterName { get; set; }
		public FilterTypesEnum FilterTypes { get; set; }

		public override string ToString()
		{
			return FilterName;
		}

		public string FilterValue { get; set; }		//String because it's use by a restful service anyways.
	}
	public enum GenreTypesEnum
	{ 
		All = 1,
		Fiction,
		Classics,
		Fantasy,
		Humor,
		History,
		Others
	}
	public enum FilterTypesEnum
	{
		Genre = 1,
		Author, 
		Title,
		MinAvgRating
	}
}