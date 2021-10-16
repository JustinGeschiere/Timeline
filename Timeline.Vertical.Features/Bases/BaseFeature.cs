using System;
using Timeline.Vertical.Features.Interfaces;

namespace Timeline.Vertical.Features.Bases
{
	public abstract class BaseFeature<TValidator, THandler, TCommand, TResult> : IFeature<TCommand, TResult>
	{
		private readonly IValidator<TCommand> _validator;
		private readonly IHandler<TCommand, TResult> _handler;

		public BaseFeature(IValidator<TCommand> validator, IHandler<TCommand, TResult> handler)
		{
			_validator = validator ?? throw new ArgumentNullException(nameof(validator));
			_handler = handler ?? throw new ArgumentNullException(nameof(handler));
		}

		public TResult Execute(TCommand command)
		{
			_validator.Validate(command);
			return _handler.Handle(command);
		}
	}
}
