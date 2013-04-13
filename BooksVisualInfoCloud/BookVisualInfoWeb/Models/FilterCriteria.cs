using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackFive.BookVisualInfoWeb.Models
{
	public class FilterCriteria
	{
		private const int DEFAULT_TAKE = 50;
		private int BookId { get; set; }
		public long Take { get; set; }

		List<BaseFilterModel> filters { get; set; }

		public FilterCriteria() 
		{
			Take = DEFAULT_TAKE;
			filters = new List<BaseFilterModel>();
		}
	}
}