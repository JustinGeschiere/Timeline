using Microsoft.Extensions.DependencyInjection;
using Timeline.Vertical.Features.Persons;

namespace Timeline.Vertical.Features
{
	public static class DependencyInjectionExtensions
	{
		public static IServiceCollection AddFeatures(this IServiceCollection services)
		{
			services.AddScoped<GetPagedPersonOverviewFeature>()
				.AddScoped<GetPagedPersonOverviewFeature.Validator>()
				.AddScoped<GetPagedPersonOverviewFeature.Handler>();

			services.AddScoped<CreatePersonFeature>()
				.AddScoped<CreatePersonFeature.Validator>()
				.AddScoped<CreatePersonFeature.Handler>();

			services.AddScoped<DeletePersonFeature>()
				.AddScoped<DeletePersonFeature.Validator>()
				.AddScoped<DeletePersonFeature.Handler>();

			services.AddScoped<GetPersonFeature>()
				.AddScoped<GetPersonFeature.Validator>()
				.AddScoped<GetPersonFeature.Handler>();

			return services;
		}
	}
}
