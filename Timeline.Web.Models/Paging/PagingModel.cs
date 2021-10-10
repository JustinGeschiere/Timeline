namespace Timeline.Web.Models.Paging
{
	public struct PagingModel
	{
		public PagingModel(int currentPage, int pageSize, int totalCount)
		{
			CurrentPage = currentPage;
			PageSize = pageSize;
			TotalCount = totalCount;

			TotalPages = TotalCount / PageSize;
			if (TotalCount % PageSize > 0)
			{
				TotalPages++;
			}
		}

		public int CurrentPage { get; }

		public int PageSize { get; }

		public int TotalCount { get; }

		public int TotalPages { get; }
	}
}
