using Timeline.Repositories.Interfaces;
using Timeline.Services.Interfaces;
using Timeline.Web.Models.Persons;
using Timeline.Web.Models.Paging;
using System.Linq;
using Timeline.Services.Helpers;

namespace Timeline.Services.Implementations
{
	internal class PersonsService : IPersonsService
	{
		private readonly IPersonsRepository _personsRepository;

		public PersonsService(IPersonsRepository personsRepository)
		{
			_personsRepository = personsRepository;
		}

		public IndexModel GetIndexModel(int currentPage, int pageSize)
		{
			var query = _personsRepository.Get();

			var totalCount = query.Count();
			var entities = PagingHelper.GetPage(query, currentPage, pageSize);
			
			var items = entities.Select(i => new IndexItemModel(i));
			var paging = new PagingModel(currentPage, pageSize, totalCount);

			return new IndexModel(items, paging);
		}
	}
}
