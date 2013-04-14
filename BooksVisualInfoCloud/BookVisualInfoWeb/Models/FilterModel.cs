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

	/// <summary>
	/// Here we were trying to limit the genre's available to the user to make their experience easier.  
	/// The issue is that alot of the books are unlabeled in genre or have some 'hybrid' genre and these 
	/// won't even cover 30% of the genre's applicable.
	/// </summary>
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

	/// <summary>
	/// The filters we intend to support
	/// </summary>
	public enum FilterTypesEnum
	{
		Genre = 1,
		Author, 
		Title,
		MinAvgRating
	}
}