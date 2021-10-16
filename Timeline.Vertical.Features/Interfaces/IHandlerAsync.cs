using System.Threading.Tasks;

namespace Timeline.Vertical.Features.Interfaces
{
	public interface IHandlerAsync<TCommand, TResult>
	{
		Task<TResult> HandleAsync(TCommand command);
	}
}
