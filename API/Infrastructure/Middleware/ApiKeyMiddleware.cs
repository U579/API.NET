namespace Infrastructure.Middleware
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _config;
        private const string HeaderName = "X-API-KEY";

        public ApiKeyMiddleware(RequestDelegate next, IConfiguration config)
        {
            _next = next;
            _config = config;
        }

        public async Task InvokeAsync(HttpContext context)
        {
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
