using System.Threading.Tasks;

namespace Timeline.Vertical.Features.Interfaces
{
	public interface IHandler<TCommand, TResult>
	{
		TResult Handle(TCommand command);
	}
}
