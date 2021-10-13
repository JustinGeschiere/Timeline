using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Timeline.Services.Interfaces;

namespace Timeline.Web.Middleware
{
	public class PersonContextMiddleware
	{
		private readonly RequestDelegate _next;

		public PersonContextMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			if (context.Request.Cookies.TryGetValue(IPersonContext.COOKIE_KEY, out var dibsedPerson))
			{
				var dibsClaim = new Claim(IPersonContext.CLAIM_KEY, dibsedPerson);
				var dibsIdentity = new ClaimsIdentity(new Claim[] { dibsClaim });
				context.User.AddIdentity(dibsIdentity);
			}

			await _next.Invoke(context);
		}
	}
}
