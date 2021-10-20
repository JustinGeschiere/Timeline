using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Timeline.Data;
using Timeline.Data.Entities;
using Timeline.Vertical.Features.Bases;
using Timeline.Vertical.Features.Helpers;
using Timeline.Vertical.Features.Interfaces;
using Timeline.Web.Models.Paging;

namespace Timeline.Vertical.Features.Persons
{
	public class GetPersonsFeatureAsync : BaseFeatureAsync<GetPersonsFeatureAsync.Validator, GetPersonsFeatureAsync.Handler, GetPersonsFeatureAsync.Command, GetPersonsFeatureAsync.Result>
	{
		public GetPersonsFeatureAsync(Validator validator, Handler handler)
			: base(validator, handler)
		{ }

		public class Command
		{
			public IEnumerable<Guid> Ids { get; set; }

			[Range(1, ushort.MaxValue)]
			public ushort CurrentPage { get; set; } = 1;

			[Range(1, ushort.MaxValue)]
			public ushort PageSize { get; set; } = 10;
		}

		public class Result
		{
			public Person[] Data { get; set; }

			public PagingModel Paging { get; set; }
		}

		public class Validator : IValidator<Command>
		{
			public void Validate(Command command)
			{
				var exceptions = ValidationHelper.ValidateAnnotations(command);

				if (exceptions.Any())
				{
					throw new AggregateException(exceptions);
				}
			}
		}

		public class Handler : IHandlerAsync<Command, Result>
		{
			private readonly TimelineContext _context;

			public Handler(TimelineContext context)
			{
				_context = context;
			}

			public async Task<Result> HandleAsync(Command command)
			{
				IQueryable<Person> query = _context.Persons;

				if (command.Ids?.Any() == true)
				{
					query = query.Where(i => command.Ids.Contains(i.Id));
				}

				var entities = await PagingHelper.GetPage(query, command.CurrentPage, command.PageSize).ToArrayAsync();
				var paging = await PagingHelper.GetPagingModel(query, command.CurrentPage, command.PageSize);

				return new Result()
				{
					Data = entities,
					Paging = paging
				};
			}
		}
	}
}
