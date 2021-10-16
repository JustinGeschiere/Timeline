using System.Threading.Tasks;

namespace Timeline.Vertical.Features.Interfaces
{
	public interface IValidator<TCommand>
	{
		void Validate(TCommand command);
	}
}
