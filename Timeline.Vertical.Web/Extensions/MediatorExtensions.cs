using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Timeline.Vertical.Features.Interfaces;

namespace Timeline.Vertical.Web.Extensions
{
	public static class MediatorExtensions
	{
		public static IActionResult ExecuteView<TCommand, TResult>(this Controller controller, IFeature<TCommand, TResult> feature, TCommand command)
		{
			return controller.View(feature.Execute(command));
		}

		public static async Task<IActionResult> ExecuteView<TCommand, TResult>(this Controller controller, IFeatureAsync<TCommand, TResult> feature, TCommand command)
		{
			return controller.View(await feature.ExecuteAsync(command));
		}

		public static IActionResult ExecuteOk<TCommand, TResult>(this Controller controller, IFeature<TCommand, TResult> feature, TCommand command)
		{
			return controller.Ok(feature.Execute(command));
		}

		public static async Task<IActionResult> ExecuteOk<TCommand, TResult>(this Controller controller, IFeatureAsync<TCommand, TResult> feature, TCommand command)
		{
			return controller.Ok(await feature.ExecuteAsync(command));
		}

		public static IActionResult ExecuteContent<TCommand, TResult>(this Controller controller, IFeature<TCommand, TResult> feature, TCommand command)
		{
			return controller.Content(feature.Execute(command).ToString());
		}

		public static async Task<IActionResult> ExecuteContent<TCommand, TResult>(this Controller controller, IFeatureAsync<TCommand, TResult> feature, TCommand command)
		{
			return controller.Content((await feature.ExecuteAsync(command)).ToString());
		}

		public static IActionResult ExecuteJson<TCommand, TResult>(this Controller controller, IFeature<TCommand, TResult> feature, TCommand command)
		{
			return controller.Json(feature.Execute(command));
		}

		public static async Task<IActionResult> ExecuteJson<TCommand, TResult>(this Controller controller, IFeatureAsync<TCommand, TResult> feature, TCommand command)
		{
			return controller.Json((await feature.ExecuteAsync(command)));
		}
	}
}
