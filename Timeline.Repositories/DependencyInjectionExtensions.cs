using Microsoft.Extensions.DependencyInjection;
using Timeline.Repositories.Implementations;
using Timeline.Repositories.Interfaces;

namespace Timeline.Repositories
{
	public static class DependencyInjectionExtensions
	{
		// TODO: Check if repository layer is needed, is EF Core repository implementation enough?
		public static IServiceCollection AddTimelineRepositories(this IServiceCollection services)
		{
			return services
				.AddScoped<IPersonsRepository, PersonsRepository>();
		}
	}
}
