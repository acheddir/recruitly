namespace Recruitly.Common.Mediator;

/// <summary>
/// Represents a query interface that defines a request to perform a read operation
/// </summary>
/// <typeparam name="TResponse">
/// The type of the response expected from the query operation.
/// </typeparam>
public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
