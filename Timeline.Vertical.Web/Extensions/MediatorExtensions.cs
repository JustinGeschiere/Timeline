using Microsoft.AspNetCore.Mvc;
using Timeline.Vertical.Features.Interfaces;

namespace Timeline.Vertical.Web.Extensions
{
	public static class MediatorExtensions
	{
		public static IActionResult ExecuteView<TCommand, TResult>(this Controller controller, IFeature<TCommand, TResult> feature, TCommand command)
		{
			return controller.View(feature.Execute(command));
		}

		public static IActionResult ExecuteOk<TCommand, TResult>(this Controller controller, IFeature<TCommand, TResult> feature, TCommand command)
		{
			return controller.Ok(feature.Execute(command));
		}

		public static IActionResult ExecuteContent<TCommand, TResult>(this Controller controller, IFeature<TCommand, TResult> feature, TCommand command)
		{
			return controller.Content(feature.Execute(command).ToString());
		}
	}
}
