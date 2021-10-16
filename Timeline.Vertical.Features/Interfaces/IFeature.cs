using System.Threading.Tasks;

namespace Timeline.Vertical.Features.Interfaces
{
	public interface IFeature<TCommand, TResult>
	{
		TResult Execute(TCommand command);
	}
}
