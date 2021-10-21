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
			[Required]
			public Guid Id { get; set; }
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
				var entity = await _context.Persons.FindAsync(command.Id);

				if (entity == null)
				{
					throw new ArgumentException("No person could be found");
				}

				return new Result()
				{
					Data = entity
				};
			}
		}
	}
}
