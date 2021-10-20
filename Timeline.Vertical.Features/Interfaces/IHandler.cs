﻿using System.Threading.Tasks;

namespace Timeline.Vertical.Features.Interfaces
{
	public interface IHandler
	{ }

	public interface IHandler<TCommand, TResult> : IHandler
	{
		TResult Handle(TCommand command);
	}

	public interface IHandlerAsync<TCommand, TResult> : IHandler
	{
		Task<TResult> HandleAsync(TCommand command);
	}
}
