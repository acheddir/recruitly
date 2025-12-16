namespace Recruitly.Common.Requests;

public static class RequestValidationModule
{
    public static IServiceCollection AddRequestValidation(this IServiceCollection services, Type type) =>
        services.AddValidatorsFromAssemblyContaining(type, includeInternalTypes: true);
}
