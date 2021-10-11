using System.Collections.Generic;
using Timeline.Web.Models.Paging;

namespace Timeline.Web.Models.Persons
{
	public class IndexModel
	{
		public IndexModel(IEnumerable<IndexItemModel> items, PagingModel paging)
		{
			Items = items;
			Paging = paging;
		}

		public IEnumerable<IndexItemModel> Items { get; }

		public PagingModel Paging { get; }
	}
}
