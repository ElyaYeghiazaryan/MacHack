using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackFive.BookVisualInfoWeb.Models
{
	public abstract class BaseFilterModel
	{
		public string ImagePath { get; set; }
		public string FilterName { get; set; }
		public FilterTypesEnum FilterTypes { get; set; }

		public override string ToString()
		{
			return FilterName;
		}

		public abstract string FilterValue { get; set; }		//String because it's use by a restful service anyways.
	}
	public enum GenreTypesEnum
	{ 
		All = 1,
		Mystery,
		SciFi,
		HistoricalFiction,
		History,
		Biography,
		Mythology,
		Others
	}
	public enum FilterTypesEnum
	{
		Genre = 1,
		Author, 
		Title,
		Publisher,
		MinAvgRating,
		MaxAvgRating
	}
}