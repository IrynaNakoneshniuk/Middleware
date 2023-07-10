using Microsoft.AspNetCore.Authentication;
using Middleware.PipelineMiddleware;
using Middleware.PipelineMiddlewear;

namespace PipelineCustomMiddleware.PipelineMiddleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorHandling(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ErrorHandlingMiddleware>();
        }

        public static IApplicationBuilder UseCustomAuthentication(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CustomAuthenticationMiddleware>();
        }

        public static IApplicationBuilder UseCustomRouting(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CustomRoutingMiddleware>();
        }
    }
}
