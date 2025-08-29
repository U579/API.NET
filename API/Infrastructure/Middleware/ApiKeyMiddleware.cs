using Microsoft.Extensions.Configuration;

namespace Infrastructure.Middleware
{
    public class ApiKeyMiddleware(RequestDelegate next, IConfiguration config)
    /// <summary>
    /// Middleware that validates the presence and correctness of an API key in the request headers.
    /// Allows requests to Swagger and favicon endpoints without validation.
    /// If the API key is missing or invalid, responds with a 401 Unauthorized status and an error message.
    /// </summary>
    /// <param name="context">The current HTTP context.</param>
    /// <returns>A task that represents the completion of request processing.</returns>
    {
        private readonly RequestDelegate _next = next;
        private readonly IConfiguration _config = config;
        private const string HeaderName = "X-API-KEY";

        /// <summary>
        /// Invokes the middleware to process the HTTP request.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path.Value;

            if (path != null && (path.StartsWith("/swagger") || path.StartsWith("/favicon")))
            {
                await _next(context);
                return;
            }

            var validKey = _config["Security:ApiKey"];

            if (!context.Request.Headers.TryGetValue(HeaderName, out var apiKey) || apiKey != validKey)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("API Key inválida.");
                return;
            }

            await _next(context);
        }
    }

    /// <summary>
    /// Extension methods for the <see cref="ApiKeyMiddleware"/>.
    /// </summary>
    public static class ApiKeyMiddlewareExtensions
    {
        public static IApplicationBuilder UseApiKeyMiddleware(this IApplicationBuilder app) =>
            app.UseMiddleware<ApiKeyMiddleware>();
    }
}
