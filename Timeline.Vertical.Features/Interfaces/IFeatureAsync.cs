using System.Threading.Tasks;

namespace Timeline.Vertical.Features.Interfaces
{
	public interface IFeatureAsync<TCommand, TResult>
	{
		Task<TResult> ExecuteAsync(TCommand command);
	}
}
