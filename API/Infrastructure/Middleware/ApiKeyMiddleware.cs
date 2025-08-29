using Microsoft.Extensions.Configuration;

namespace Infrastructure.Middleware
{
    public class ApiKeyMiddleware(RequestDelegate next, IConfiguration config)
    {
        private readonly RequestDelegate _next = next;
        private readonly IConfiguration _config = config;
        private const string HeaderName = "X-API-KEY";

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

    public static class ApiKeyMiddlewareExtensions
    {
        public static IApplicationBuilder UseApiKeyMiddleware(this IApplicationBuilder app) =>
            app.UseMiddleware<ApiKeyMiddleware>();
    }
}
