using Microsoft.AspNetCore.Mvc;
using Timeline.Services.Interfaces;
using Timeline.Web.Models.Persons;

namespace Timeline.Web.Controllers
{
	public class PersonsController : Controller
	{
		private readonly IPersonsService _personsService;
		private readonly IPersonContext _personContext;

		public PersonsController(IPersonsService personsService, IPersonContext personContext)
		{
			_personsService = personsService;
			_personContext = personContext;
		}

		public IActionResult Index()
		{
			// TODO: Use input for paging values
			var model = _personsService.GetIndexModel(1, 10);

			return View(model);
		}

		public IActionResult Me()
		{
			var person = _personContext.CurrentPerson;
			return Content(_personContext.CurrentPerson?.FirstName ?? "No dibsed person");
		}

		public IActionResult Dibs([FromQuery] DibsInputModel model)
		{
			if (ModelState.IsValid && _personContext.CurrentPerson == null)
			{
				var person = _personsService.GetPersonByName(model.Name);

				if (person != null)
				{
					HttpContext.Response.Cookies.Append(IPersonContext.COOKIE_KEY, person.Id.ToString());
				}

				return Ok();
			}

			return BadRequest();
		}

		public IActionResult ReleaseDibs()
		{
			HttpContext.Response.Cookies.Delete(IPersonContext.COOKIE_KEY);

			return Ok();
		}

		public IActionResult Create([FromQuery] CreateInputModel input)
		{
			if (ModelState.IsValid)
			{
				_personsService.AddPerson(input);
				return RedirectToAction(nameof(Index));
			}

			return BadRequest();
		}

		public IActionResult Delete([FromQuery] DeleteInputModel input)
		{
			if (ModelState.IsValid)
			{
				_personsService.DeletePerson(input);
				return RedirectToAction(nameof(Index));
			}

			return BadRequest();
		}
	}
}
