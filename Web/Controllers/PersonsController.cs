using Microsoft.AspNetCore.Mvc;
using Timeline.Services.Interfaces;

namespace Timeline.Web.Controllers
{
	public class PersonsController : Controller
	{
		private readonly IPersonsService _personsService;

		public PersonsController(IPersonsService personsService)
		{
			_personsService = personsService;
		}

		public IActionResult Index()
		{
			// TODO: Use input for paging values
			var model = _personsService.GetIndexModel(1, 10);

			return View(model);
		}
	}
}
