using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackFive.BookVisualInfoWeb.Models
{
	/// <summary>
	/// To be used by JQuery to filter what books come back.
	/// </summary>
	public class FilterCriteria
	{
		public const int DEFAULT_TAKE = 50;
		public int BookId { get; set; }
		public long Take { get; set; }

		public List<BaseFilterModel> filters { get; set; }

		public FilterCriteria() 
		{
			Take = DEFAULT_TAKE;
			filters = new List<BaseFilterModel>();
		}
	}
}