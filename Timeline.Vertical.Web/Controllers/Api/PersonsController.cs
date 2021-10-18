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
		[HttpGet("GetPerson")]
		public async Task<IActionResult> GetPersonAsync([FromServices] GetPersonFeature feature, [FromQuery] GetPersonFeature.Command command)
		{
			return await this.ExecuteJson(feature, command);
		}

		[HttpGet("GetPersons")]
		public async Task<IActionResult> GetPersonsAsync([FromServices] object feature, [FromQuery] object command)
		{
			throw new System.NotImplementedException();
			//return await this.ExecuteJson(feature, command);
		}
	}
}
