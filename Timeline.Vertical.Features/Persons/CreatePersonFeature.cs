using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Timeline.Data;
using Timeline.Data.Entities;
using Timeline.Vertical.Features.Bases;
using Timeline.Vertical.Features.Helpers;
using Timeline.Vertical.Features.Interfaces;

namespace Timeline.Vertical.Features.Persons
{
	public class CreatePersonFeature : BaseFeature<CreatePersonFeature.Validator, CreatePersonFeature.Handler, CreatePersonFeature.Command, CreatePersonFeature.Result>
	{
		public CreatePersonFeature(Validator validator, Handler handler)
			: base(validator, handler)
		{ }

		public class Command
		{
			[Required(AllowEmptyStrings = false)]
			[MaxLength(20)]
			public string Name { get; set; }
		}

		public class Result
		{
			public Person Data { get; set; }

			public override string ToString()
			{
				return JsonConvert.SerializeObject(this);
			}
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

		public class Handler : IHandler<Command, Result>
		{
			private readonly TimelineContext _context;

			public Handler(TimelineContext context)
			{
				_context = context;
			}

			public Result Handle(Command command)
			{
				var existing = _context.Persons.FirstOrDefault(i => i.Name.Equals(command.Name));
				if (existing != null)
				{
					throw new ArgumentException("A person with this name already exists");
				}

				var utcNow = DateTime.UtcNow;

				var entity = new Person()
				{
					Id = Guid.NewGuid(),
					Name = command.Name,
					Created = utcNow,
					Modified = utcNow
				};

				_context.Persons.Add(entity);
				_context.SaveChanges();

				return new Result()
				{
					Data = entity
				};
			}
		}
	}
}
