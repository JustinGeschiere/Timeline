using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Timeline.Data;
using Timeline.Vertical.Features.Bases;
using Timeline.Vertical.Features.Interfaces;
using Timeline.Web.Models.Paging;
using Timeline.Web.Models.Persons;

namespace Timeline.Vertical.Features.Persons
{
	public class GetPagedPersonOverviewFeature : BaseFeature<GetPagedPersonOverviewFeature.Validator, GetPagedPersonOverviewFeature.Handler, GetPagedPersonOverviewFeature.Command, GetPagedPersonOverviewFeature.Result>
	{
		public GetPagedPersonOverviewFeature(Validator validator, Handler handler)
			: base(validator, handler)
		{ }

		public class Command
		{
			public ushort CurrentPage { get; set; } = 1;
			public ushort PageSize { get; set; } = 10;
		}

		public class Result
		{
			public IndexModel Model { get; set; }
		}

		public class Validator : IValidator<Command>
		{
			public void Validate(Command command)
			{
				var exceptions = new List<Exception>();

				// Some custom validation for now, use data annotations later
				if (command.CurrentPage < 1)
				{
					exceptions.Add(new ValidationException($"{nameof(command.CurrentPage)} has a minimal value of 1"));
				}

				if (command.PageSize < 1)
				{
					exceptions.Add(new ValidationException($"{nameof(command.PageSize)} has a minimal value of 1"));
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
				var skip = (command.CurrentPage - 1) * command.PageSize;
				var take = command.PageSize;

				var query = _context.Persons;
				var persons = query.Skip(skip).Take(take);

				var items = persons.Select(i => new IndexItemModel(i));
				var paging = new PagingModel(command.CurrentPage, command.PageSize, query.Count());

				var model = new IndexModel(items, paging);

				return new Result()
				{
					Model = model
				};
			}
		}
	}
}
