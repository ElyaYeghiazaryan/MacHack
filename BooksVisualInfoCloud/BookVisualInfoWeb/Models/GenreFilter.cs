using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackFive.BookVisualInfoWeb.Models
{
	/// <summary>
	/// Filters by Genre
	/// </summary>
	
	/* Obsoletede due to change last minute
	 * public class GenreFilter : BaseFilterModel
	{
		public override string FilterValue
		{
			get
			{
				return GenreTypeValue.ToString();
			}
			set
			{
				GenreTypeValue = Int32.Parse(value);
			}
		}
		public int GenreTypeValue { get; set; }
		public GenreTypesEnum GenreType
		{
			get { return (GenreTypesEnum)GenreTypeValue; }
			set { GenreTypeValue = (int)value; }
		}
		public string GenreName
		{
			get
			{
				return GenreType.ToString();
			}
		}

		public override string ToString()
		{
			return String.Concat(base.ToString(), ".", GenreName);
		}
	}*/
}