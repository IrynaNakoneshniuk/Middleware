using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using System.Reflection.PortableExecutable;

namespace PipelineCustomMiddleware.PipelineMiddleware
{
    public  class CustomRoutingMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomRoutingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.ContentType = "text/html; charset=utf-8";
            string path = context.Request.Path.Value != null ? context.Request.Path.Value.ToLower() : "";

            var password = "4321";
            var login = "1234";

            if (path =="/home")
            {
                await context.Response.WriteAsync("<h2>Домашня сторінка</h2>");
            }
            else if(path== "/mypicture")
            {
                await context.Response.SendFileAsync("Pages/mypicture.html");
            }
            else if (path == "/mycredential")
            {
                await context.Response.WriteAsJsonAsync(new AuthenticationUser(login,password));
            }
            else
            {
                context.Response.StatusCode = 404;
            }
        }
    }

    record AuthenticationUser(string login, string password);
}