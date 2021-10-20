namespace Timeline.Web.Models.Paging
{
	public struct PagingModel
	{
		public PagingModel(int currentPage, int pageSize, int totalCount)
		{
			CurrentPage = currentPage;
			PageSize = pageSize;
			TotalCount = totalCount;

			TotalPages = totalCount / pageSize;
			if (totalCount % pageSize > 0)
			{
				TotalPages++;
			}

			var skip = (currentPage - 1) * pageSize;
			HasNextPage = totalCount > pageSize && skip * pageSize < totalCount;
		}

		public int CurrentPage { get; }

		public int PageSize { get; }

		public int TotalCount { get; }

		public int TotalPages { get; }

		public bool HasNextPage { get; }
	}
}
