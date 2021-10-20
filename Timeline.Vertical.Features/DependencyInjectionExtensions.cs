using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;
using Timeline.Vertical.Features.Interfaces;

namespace Timeline.Vertical.Features
{
	public static class DependencyInjectionExtensions
	{
		public static IServiceCollection AddFeatures(this IServiceCollection services)
		{
			return services.AddAssemblyFeatures();
		}

		private static IServiceCollection AddAssemblyFeatures(this IServiceCollection services)
		{
			var currentAssembly = Assembly.GetExecutingAssembly();

			// Features
			var featureInterface = typeof(IFeature);
			var features = currentAssembly.GetTypes().Where(i => featureInterface.IsAssignableFrom(i) && !i.IsAbstract && !i.IsInterface);

			foreach (var feature in features)
			{
				services.AddScoped(feature);
			}

			// Validator
			var validatorInterface = typeof(IValidator);
			var validators = currentAssembly.GetTypes().Where(i => validatorInterface.IsAssignableFrom(i) && !i.IsAbstract && !i.IsInterface);

			foreach (var validator in validators)
			{
				services.AddScoped(validator);
			}

			// Handlers
			var handlerInterface = typeof(IHandler);
			var handlers = currentAssembly.GetTypes().Where(i => handlerInterface.IsAssignableFrom(i) && !i.IsAbstract && !i.IsInterface);

			foreach (var handler in handlers)
			{
				services.AddScoped(handler);
			}

			return services;
		}
	}
}
