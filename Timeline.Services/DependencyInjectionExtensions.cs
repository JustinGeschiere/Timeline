using Microsoft.Extensions.DependencyInjection;
using Timeline.Services.Implementations;
using Timeline.Services.Interfaces;

namespace Timeline.Services
{
	public static class DependencyInjectionExtensions
	{
		public static IServiceCollection AddTimelineServices(this IServiceCollection services)
		{
			return services
				.AddScoped<IPersonsService, PersonsService>();
		}
	}
}
