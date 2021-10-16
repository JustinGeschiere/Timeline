using System.Threading.Tasks;

namespace Timeline.Vertical.Features.Interfaces
{
	public interface IValidator
	{ }

	public interface IValidator<TCommand> : IValidator
	{
		void Validate(TCommand command);
	}

	public interface IValidatorAsync<TCommand> : IValidator
	{
		Task<bool> ValidateAsync(TCommand command);
	}
}
