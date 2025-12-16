namespace Recruitly.Common.Requests;

public class RequestValidationApiFilter<TRequest> : IEndpointFilter where TRequest : class
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        if (context.Arguments.OfType<TRequest>().FirstOrDefault() is not { } request)
        {
            Dictionary<string, string[]> validationErrors =
                new() { ["body"] = ["Invalid or missing request body"] };
            return Results.ValidationProblem(validationErrors);
        }

        IValidator<TRequest>? validator = context.HttpContext.RequestServices.GetService<IValidator<TRequest>>();

        if (validator is null)
        {
            return await next.Invoke(context);
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
