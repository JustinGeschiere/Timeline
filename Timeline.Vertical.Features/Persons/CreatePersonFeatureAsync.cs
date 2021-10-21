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
	public class CreatePersonFeatureAsync : BaseFeatureAsync<CreatePersonFeatureAsync.Validator, CreatePersonFeatureAsync.Handler, CreatePersonFeatureAsync.Command, CreatePersonFeatureAsync.Result>
	{
		public CreatePersonFeatureAsync(Validator validator, Handler handler)
			: base(validator, handler)
		{ }

		public class Command
		{
			[Required]
			[MaxLength(50)]
			public string FirstName { get; set; }

			[Required]
			[MaxLength(50)]
			public string LastName { get; set; }

			[Required]
			[MaxLength(50)]
			[DataType(DataType.EmailAddress)]
			public string EmailAddress { get; set; }
		}

		public class Result
		{
			public Person Person { get; set; }
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
				if (await _context.Persons.AnyAsync(i => i.EmailAddress.Equals(command.EmailAddress)))
				{
					throw new InvalidOperationException("The provided e-mail address is already in use");
				}

				var utcNow = DateTime.UtcNow;

				var entity = new Person()
				{
					Id = Guid.NewGuid(),
					FirstName = command.FirstName.Trim(),
					LastName = command.LastName.Trim(),
					EmailAddress = command.EmailAddress.ToLower().Trim(),
					Created = utcNow,
					Modified = utcNow
				};

				_context.Persons.Add(entity);
				await _context.SaveChangesAsync();

				return new Result
				{
					Person = entity
				};
			}
		}
	}
}
