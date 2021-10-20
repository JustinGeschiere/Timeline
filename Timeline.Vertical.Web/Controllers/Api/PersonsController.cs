using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Timeline.Vertical.Features.Persons;
using Timeline.Vertical.Web.Extensions;

namespace Timeline.Vertical.Web.Controllers.Api
{
	[Route("api/[controller]")]
	[ApiController]
	public class PersonsController : Controller
	{
		#region Queries
		[HttpGet("GetPerson")]
		public async Task<IActionResult> GetPersonAsync([FromServices] GetPersonFeatureAsync feature, [FromQuery] GetPersonFeatureAsync.Command command)
		{
			return await this.ExecuteJson(feature, command);
		}

		[HttpGet("GetPersons")]
		public async Task<IActionResult> GetPersonsAsync([FromServices] GetPersonsFeatureAsync feature, [FromQuery] GetPersonsFeatureAsync.Command command)
		{
			return await this.ExecuteJson(feature, command);
		}

		[HttpGet("SearchPersons")]
		public async Task<IActionResult> SearchPersonsAsync([FromServices] SearchPersonsFeatureAsync feature, [FromQuery] SearchPersonsFeatureAsync.Command command)
		{
			return await this.ExecuteJson(feature, command);
		}
		#endregion

		#region Commands
		[HttpPost("CreatePerson")]
		public async Task<IActionResult> CreatePersonAsync([FromServices] CreatePersonFeatureAsync feature, [FromQuery] CreatePersonFeatureAsync.Command command)
		{
			return await this.ExecuteOk(feature, command);
		}

		[HttpPost("DeletePerson")]
		public async Task<IActionResult> DeletePersonAsync([FromServices] DeletePersonFeatureAsync feature, [FromQuery] DeletePersonFeatureAsync.Command command)
		{
			return await this.ExecuteOk(feature, command);
		}
		#endregion
	}
}
