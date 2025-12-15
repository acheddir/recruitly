namespace Recruitly.Common.Requests;

public class RequestValidationApiFilter<TRequest> : IEndpointFilter where TRequest : class
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        TRequest? request =
            context.Arguments.OfType<TRequest>().FirstOrDefault();

        IValidator<TRequest>? validator = context.HttpContext.RequestServices.GetService<IValidator<TRequest>>();

        if (validator is null)
        {
            return await next.Invoke(context);
        }

        if (request is null)
        {
            return Results.ValidationProblem(
                new Dictionary<string, string[]>
                {
                    { "Request", new[] { "Request payload is missing or invalid." } }
                },
                statusCode: (int)HttpStatusCode.BadRequest
            );
        }

        ValidationResult? validationResult = await validator.ValidateAsync(request);
        if (validationResult.IsValid)
        {
            return await next.Invoke(context);
        }

        IDictionary<string, string[]>? errors = validationResult.ToDictionary();

        return Results.ValidationProblem(errors, statusCode: (int)HttpStatusCode.BadRequest);
    }
}
