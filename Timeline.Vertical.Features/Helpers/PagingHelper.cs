using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timeline.Web.Models.Paging;

namespace Timeline.Vertical.Features.Helpers
{
	internal static class PagingHelper
	{
		private static int CalculateSkip(int currentPage, int pageSize)
		{
			return (currentPage - 1) * pageSize;
		}

		private static bool HasNextPage(int skip, int take, int totalCount)
		{
			return skip + take < totalCount;
		}

		public static IQueryable<T> GetPage<T>(IQueryable<T> query, int currentPage, int pageSize)
		{
			return query.Skip(CalculateSkip(currentPage, pageSize)).Take(pageSize);
		}

		public static async Task<PagingModel> GetPagingModel<T>(IQueryable<T> query, int currentPage, int pageSize)
		{
			var totalCount = await query.CountAsync();
			return new PagingModel(currentPage, pageSize, totalCount);
		}
	}
}
