using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Timeline.Data;
using Timeline.Vertical.Features.Bases;
using Timeline.Vertical.Features.Interfaces;

namespace Timeline.Vertical.Features.Persons
{
	public class DeletePersonFeature : BaseFeature<DeletePersonFeature.Validator, DeletePersonFeature.Handler, DeletePersonFeature.Command, DeletePersonFeature.Result>
	{
		public DeletePersonFeature(Validator validator, Handler handler)
			: base(validator, handler)
		{ }

		public class Command
		{
			public string Name { get; set; }
		}

		public class Result
		{
			public Guid DeletedId { get; set; }
			public string DeletedName { get; set; }

			public override string ToString()
			{
				return JsonConvert.SerializeObject(this);
			}
		}

		public class Validator : IValidator<Command>
		{
			public void Validate(Command command)
			{
				var exceptions = new List<Exception>();

				// Some custom validation for now, use data annotations later
				if (string.IsNullOrWhiteSpace(command.Name))
				{
					exceptions.Add(new ValidationException($"{nameof(command.Name)} is required"));
				}

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
				var entity = _context.Persons.FirstOrDefault(i => i.Name.Equals(command.Name));
				if (entity == null)
				{
					throw new ArgumentException("A person with this name could not be found");
				}

				_context.Persons.Remove(entity);
				_context.SaveChanges();

				return new Result()
				{
					DeletedId = entity.Id,
					DeletedName = entity.Name
				};
			}
		}
	}
}
