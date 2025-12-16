namespace Recruitly.Common.Requests;

public static class RequestValidationExtensions
{
    extension(RouteHandlerBuilder builder)
    {
        public RouteHandlerBuilder ValidateRequest<TRequest>()
            where TRequest : class =>
            builder.AddEndpointFilter<RequestValidationApiFilter<TRequest>>();
    }
}

