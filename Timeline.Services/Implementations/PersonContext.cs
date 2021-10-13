using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using Timeline.Data.Entities;
using Timeline.Repositories.Interfaces;
using Timeline.Services.Interfaces;

namespace Timeline.Services.Implementations
{
	internal class PersonContext : IPersonContext
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly IPersonsRepository _personsRepository;

		public PersonContext(IHttpContextAccessor httpContextAccessor, IPersonsRepository personsRepository)
		{
			_httpContextAccessor = httpContextAccessor;
			_personsRepository = personsRepository;
		}

		public Person CurrentPerson => GetCurrentPerson();

		private Person GetCurrentPerson()
		{
			var dibsClaim = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(i => i.Type == IPersonContext.CLAIM_KEY);

			if (dibsClaim != null)
			{
				_ = Guid.TryParse(dibsClaim.Value, out var dibsId);
				return _personsRepository.GetById(dibsId);
			}

			return null;
		}
	}
}
