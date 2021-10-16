﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Timeline.Vertical.Features.Persons;
using Timeline.Vertical.Web.Extensions;

namespace Timeline.Vertical.Web.Controllers
{
	public class PersonsController : Controller
	{
		#region Queries
		public async Task<IActionResult> Index([FromServices] GetPagedPersonOverviewFeature feature, [FromQuery] GetPagedPersonOverviewFeature.Command command)
		{
			return await this.ExecuteView(feature, command);
		}
		#endregion

		#region Commands
		public IActionResult Create([FromServices] CreatePersonFeature feature, [FromQuery] CreatePersonFeature.Command command)
		{
			return this.ExecuteContent(feature, command);
		}

		public IActionResult Delete([FromServices] DeletePersonFeature feature, [FromQuery] DeletePersonFeature.Command command)
		{
			return this.ExecuteContent(feature, command);
		}
		#endregion
	}
}
