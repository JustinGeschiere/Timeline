using Microsoft.Extensions.DependencyInjection;
using Timeline.Vertical.Features.Persons;

namespace Timeline.Vertical.Features
{
	public static class DependencyInjectionExtensions
	{
		public static IServiceCollection AddFeatures(this IServiceCollection services)
		{
			services.AddScoped<CreatePersonFeature>()
				.AddScoped<CreatePersonFeature.Validator>()
				.AddScoped<CreatePersonFeature.Handler>();

			services.AddScoped<GetPagedPersonOverviewFeature>()
				.AddScoped<GetPagedPersonOverviewFeature.Validator>()
				.AddScoped<GetPagedPersonOverviewFeature.Handler>();

			return services;
		}
	}
}
