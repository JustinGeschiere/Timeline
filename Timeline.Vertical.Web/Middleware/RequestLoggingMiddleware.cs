using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Timeline.Vertical.Web.Middleware
{
	public class RequestLoggingMiddleware
	{
		private readonly ILogger _logger;
		private readonly RequestDelegate _next;

		public RequestLoggingMiddleware(ILoggerFactory loggerFactory, RequestDelegate next)
		{
			_logger = loggerFactory.CreateLogger<RequestLoggingMiddleware>();
			_next = next;
		}

		public async Task InvokeAsync(HttpContext httpContext)
		{
			_logger.LogInformation($"Incoming request: {httpContext.Request.Path}");
			await _next.Invoke(httpContext);
		}
	}
}
