using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration;

namespace NordjyskeMediehus.API.Authentication
{
    public class ApiKeyAuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public ApiKeyAuthMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue(AuthConstants.ApiKeyHeaderName, out var extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Api key is missing");
                return;
            }

            var ApiKey = _configuration.GetValue<string>(AuthConstants.ApiKeySectionName);
            if (!ApiKey.Equals(extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Wrong Apikey");
                return;
            }

            await _next(context);
        }

    }
}
