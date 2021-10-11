using Microsoft.AspNetCore.Mvc;
using Timeline.Services.Interfaces;
using Timeline.Web.Models.Persons;

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

		public IActionResult Create([FromQuery] CreateInputModel input)
		{
			if (ModelState.IsValid)
			{
				_personsService.AddPerson(input);
			}

			return RedirectToAction(nameof(Index));
		}

		public IActionResult Delete([FromQuery] DeleteInputModel input)
		{
			if (ModelState.IsValid)
			{
				_personsService.DeletePerson(input);
			}

			return RedirectToAction(nameof(Index));
		}
	}
}
