using System.Collections.Generic;
using System.Linq;

namespace Timeline.Services.Helpers
{
	internal static class PagingHelper
	{
		public static int CalculateSkip(int currentPage, int pageSize)
		{
			return (currentPage - 1) * pageSize;
		}

		public static IEnumerable<T> GetPage<T>(IQueryable<T> query, int currentPage, int pageSize)
		{
			return query.Skip(CalculateSkip(currentPage, pageSize)).Take(pageSize).AsEnumerable();
		}
	}
}
