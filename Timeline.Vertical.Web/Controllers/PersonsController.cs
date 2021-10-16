using Microsoft.AspNetCore.Mvc;
using Timeline.Vertical.Features.Persons;
using Timeline.Vertical.Web.Extensions;

namespace Timeline.Vertical.Web.Controllers
{
	public class PersonsController : Controller
	{
		#region Queries
		public IActionResult Index([FromServices] GetPagedPersonOverviewFeature feature, [FromQuery] GetPagedPersonOverviewFeature.Command command)
		{
			return this.ExecuteView(feature, command);
		}
		#endregion

		#region Commands
		public IActionResult Create([FromServices] CreatePersonFeature feature, [FromQuery] CreatePersonFeature.Command command)
		{
			return this.ExecuteContent(feature, command);
		}
		#endregion
	}
}
