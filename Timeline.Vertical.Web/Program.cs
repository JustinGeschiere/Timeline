using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Timeline.Vertical.Web
{
	public class Program
	{
		public static void Main(string[] args)
		{
			using var host = CreateHostBuilder(args).Build();
			host.Start();
			host.WaitForShutdown();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}
