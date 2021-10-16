using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Timeline.Data;
using Timeline.Vertical.Features.Bases;
using Timeline.Vertical.Features.Helpers;
using Timeline.Vertical.Features.Interfaces;
using Timeline.Web.Models.Paging;
using Timeline.Web.Models.Persons;

namespace Timeline.Vertical.Features.Persons
{
	public class GetPagedPersonOverviewFeature : BaseFeatureAsync<GetPagedPersonOverviewFeature.Validator, GetPagedPersonOverviewFeature.Handler, GetPagedPersonOverviewFeature.Command, GetPagedPersonOverviewFeature.Result>
	{
		public GetPagedPersonOverviewFeature(Validator validator, Handler handler)
			: base(validator, handler)
		{ }

		public class Command
		{
			[Range(1, ushort.MaxValue)]
			public ushort CurrentPage { get; set; } = 1;

			[Range(1, ushort.MaxValue)]
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
				var skip = (command.CurrentPage - 1) * command.PageSize;
				var take = command.PageSize;

				var query = _context.Persons;
				var totalCount = await query.CountAsync();
				var persons = query.Skip(skip).Take(take);

				var items = persons.Select(i => new IndexItemModel(i));
				var paging = new PagingModel(command.CurrentPage, command.PageSize, totalCount);

				var model = new IndexModel(items, paging);

				return new Result()
				{
					Model = model
				};
			}
		}
	}
}
