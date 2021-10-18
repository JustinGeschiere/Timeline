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

namespace Timeline.Vertical.Features.Persons
{
	public class GetPersonsFeature : BaseFeatureAsync<GetPersonsFeature.Validator, GetPersonsFeature.Handler, GetPersonsFeature.Command, GetPersonsFeature.Result>
	{
		public GetPersonsFeature(Validator validator, Handler handler)
			: base(validator, handler)
		{ }

		public class Command
		{
			public IEnumerable<Guid> Ids { get; set; }

			public IEnumerable<string> Names { get; set; }

			[Range(1, ushort.MaxValue)]
			public ushort CurrentPage { get; set; } = 1;

			[Range(1, ushort.MaxValue)]
			public ushort PageSize { get; set; } = 10;
		}

		public class Result
		{
			public Person[] Data { get; set; }

			// TODO: Move paging to separate model class?
			public int CurrentPage { get; set; }

			public int PageSize { get; set; }

			public int TotalCount { get; set; }

			public bool HasNextPage { get; set; }
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

				if (command.Names?.Any() == true)
				{
					query = query.Where(i => command.Names.Contains(i.Name));
				}

				// TODO: Move paging logic to helper
				var skip = (command.CurrentPage - 1) * command.PageSize;
				var take = command.PageSize;

				var entities = await query.Skip(skip).Take(take).ToArrayAsync();
				var totalCount = await query.CountAsync();

				return new Result()
				{
					Data = entities,
					CurrentPage = command.CurrentPage,
					PageSize = command.PageSize,
					TotalCount = totalCount,
					HasNextPage = skip + take < totalCount
				};
			}
		}
	}
}
