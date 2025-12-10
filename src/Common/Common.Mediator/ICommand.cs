namespace Recruitly.Common.Mediator;

/// <summary>
/// Represents a command interface that defines a request to perform a mutation operation.
/// </summary>
public interface ICommand : IRequest<Result>, IBaseCommand;

/// <summary>
/// Represents a command interface that defines a request to perform a mutation operation
/// resulting in a <see cref="Result"/>.
/// </summary>
/// <typeparam name="TResponse">The type of the response object.</typeparam>
public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand;
