using Microsoft.EntityFrameworkCore;
using System;
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
	public class GetPersonFeatureAsync : BaseFeatureAsync<GetPersonFeatureAsync.Validator, GetPersonFeatureAsync.Handler, GetPersonFeatureAsync.Command, GetPersonFeatureAsync.Result>
	{
		public GetPersonFeatureAsync(Validator validator, Handler handler)
			: base(validator, handler)
		{ }

		public class Command
		{
			public Guid Id { get; set; }

			public string Name { get; set; }
		}

		public class Result
		{
			public Person Data { get; set; }
		}

		public class Validator : IValidator<Command>
		{
			public void Validate(Command command)
			{
				var exceptions = ValidationHelper.ValidateAnnotations(command);

				if (Guid.Empty.Equals(command.Id) && string.IsNullOrWhiteSpace(command.Name))
				{
					exceptions = exceptions.Append(new ValidationException($"Either {nameof(command.Id)} or {nameof(command.Name)} is required"));
				}

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

				if (!Guid.Empty.Equals(command.Id))
				{
					query = query.Where(i => i.Id == command.Id);
				}

				if (!string.IsNullOrWhiteSpace(command.Name))
				{
					query = query.Where(i => i.Name.Equals(command.Name));
				}

				var entity = await query.FirstOrDefaultAsync();

				if (entity == null)
				{
					throw new ArgumentException("No person could be found with the provided input");
				}

				return new Result()
				{
					Data = entity
				};
			}
		}
	}
}
