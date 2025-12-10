namespace Recruitly.Common.OpenAPI;

/// <summary>
/// Extension methods for adding OpenAPI response descriptions to endpoints.
/// </summary>
public static class EndpointRouteBuilderExtensions
{
    /// <param name="builder">The route handler builder.</param>
    extension(RouteHandlerBuilder builder)
    {
        /// <summary>
        /// Adds response descriptions and examples to the endpoint's OpenAPI documentation.
        /// </summary>
        /// <param name="descriptions">Dictionary mapping status codes to their descriptions.</param>
        /// <param name="examples">Dictionary mapping status codes to their example ProblemDetails objects.</param>
        /// <returns>The route handler builder for method chaining.</returns>
        private RouteHandlerBuilder WithResponseDescriptions(
            IReadOnlyDictionary<int, string> descriptions,
            Dictionary<int, ProblemDetails>? examples = null) =>
            builder.AddOpenApiOperationTransformer((operation, _, _) =>
            {
                if (operation.Responses is null)
                {
                    return Task.CompletedTask;
                }

                foreach ((int statusCode, string description) in descriptions)
                {
                    string statusCodeKey = statusCode.ToString(CultureInfo.InvariantCulture);
                    if (operation.Responses.TryGetValue(statusCodeKey, out IOpenApiResponse? response))
                    {
                        response.Description = description;

                        // Add an example if provided
                        if (examples is not null && examples.TryGetValue(statusCode, out ProblemDetails? example))
                        {
                            AddProblemDetailsExample(response, example);
                        }
                    }
                }

                return Task.CompletedTask;

                static void AddProblemDetailsExample(IOpenApiResponse response, ProblemDetails problemDetails)
                {
                    if (response.Content is null)
                    {
                        return;
                    }

                    // Try both application/problem+json and application/json content types
                    string[] contentTypes = ["application/problem+json", "application/json"];

                    foreach (string contentType in contentTypes)
                    {
                        if (response.Content.TryGetValue(contentType, out OpenApiMediaType? mediaType))
                        {
                            // Create an OpenAPI example using JsonNode
                            JsonObject exampleObject = new()
                            {
                                ["type"] = problemDetails.Type ?? "https://tools.ietf.org/html/rfc7231",
                                ["title"] = problemDetails.Title ?? "Error",
                                ["status"] = problemDetails.Status ?? 500,
                                ["detail"] = problemDetails.Detail ?? "An error occurred"
                            };

                            // Add errors property for ValidationProblemDetails
                            if (problemDetails is ValidationProblemDetails validationProblem &&
                                validationProblem.Errors.Count > 0)
                            {
                                JsonObject errorsObject = [];
                                foreach ((string key, string[] values) in validationProblem.Errors)
                                {
                                    errorsObject[key] = new JsonArray([.. values.Select(v => JsonValue.Create(v))]);
                                }

                                exampleObject["errors"] = errorsObject;
                            }

                            // Set as both the singular example and in the examples collection
                            mediaType.Example = exampleObject;

                            // Also add to the Examples collection for better OpenAPI tool support
                            mediaType.Examples ??= new Dictionary<string, IOpenApiExample>();
                            mediaType.Examples["default"] = new OpenApiExample { Value = exampleObject };

                            break; // Only set on the first matching content type
                        }
                    }
                }
            });

        /// <summary>
        /// Adds standard response descriptions for a create operation.
        /// </summary>
        /// <param name="createdDescription">Optional custom description for 201 Created response.</param>
        /// <param name="conflictDescription">Optional custom description for 409 Conflict response.</param>
        /// <returns>The route handler builder for method chaining.</returns>
        public RouteHandlerBuilder WithResponseDescriptions(string? createdDescription = null,
            string? conflictDescription = null)
        {
            Dictionary<int, string> descriptions = new()
            {
                [StatusCodes.Status201Created] = createdDescription ?? ResponseDescriptions.Create.Success,
                [StatusCodes.Status400BadRequest] = ResponseDescriptions.Create.BadRequest,
                [StatusCodes.Status401Unauthorized] = ResponseDescriptions.Common.Unauthorized,
                [StatusCodes.Status403Forbidden] = ResponseDescriptions.Common.Forbidden,
                [StatusCodes.Status409Conflict] = conflictDescription ?? ResponseDescriptions.Create.Conflict,
                [StatusCodes.Status500InternalServerError] = ResponseDescriptions.Common.InternalServerError
            };

            Dictionary<int, ProblemDetails> examples = new()
            {
                [StatusCodes.Status400BadRequest] = ProblemDetailsExamples.Create.BadRequest,
                [StatusCodes.Status401Unauthorized] = ProblemDetailsExamples.Common.Unauthorized,
                [StatusCodes.Status403Forbidden] = ProblemDetailsExamples.Common.Forbidden,
                [StatusCodes.Status409Conflict] = ProblemDetailsExamples.Create.Conflict,
                [StatusCodes.Status500InternalServerError] = ProblemDetailsExamples.Common.InternalServerError
            };

            return builder.WithResponseDescriptions(descriptions, examples);
        }
    }
}
