using Timeline.Repositories.Interfaces;
using Timeline.Services.Interfaces;
using Timeline.Web.Models.Persons;
using Timeline.Web.Models.Paging;
using System.Linq;
using Timeline.Services.Helpers;
using Timeline.Data.Entities;
using System;
using Microsoft.Extensions.Logging;

namespace Timeline.Services.Implementations
{
	internal class PersonsService : IPersonsService
	{
		private readonly IPersonsRepository _personsRepository;
		private readonly ILogger _logger;

		public PersonsService(IPersonsRepository personsRepository, ILogger<PersonsService> logger)
		{
			_personsRepository = personsRepository;
			_logger = logger;
		}

		public IndexModel GetIndexModel(int currentPage, int pageSize)
		{
			var query = _personsRepository.All();

			var totalCount = query.Count();
			var entities = PagingHelper.GetPage(query, currentPage, pageSize);
			
			var items = entities.Select(i => new IndexItemModel(i));
			var paging = new PagingModel(currentPage, pageSize, totalCount);

			return new IndexModel(items, paging);
		}

		public void AddPerson(CreateInputModel model)
		{
			var utcNow = DateTime.UtcNow;

			var entity = new Person()
			{
				Id = Guid.NewGuid(),
				Name = $"{char.ToUpper(model.Name[0])}{model.Name.Substring(1)}",
				Created = utcNow,
				Modified = utcNow
			};

			if (_personsRepository.GetByName(entity.Name) == null)
			{
				_personsRepository.Add(entity);
				_logger.LogInformation($"Added person '{entity.Name}' : '{entity.Id}'");
			}
			else
			{
				_logger.LogInformation($"Person with name '{entity.Name}' already exists");
			}
		}

		public void DeletePerson(DeleteInputModel model)
		{
			var entity = _personsRepository.GetByName(model.Name);

			if (entity != null)
			{
				_personsRepository.Remove(entity);
				_logger.LogInformation($"Removed person '{entity.Name}' : '{entity.Id}'");
			}
			else
			{
				_logger.LogInformation($"Person with name '{entity.Name}' does not exist");
			}
		}
	}
}
