namespace Middleware.PipelineMiddlewear
{
    public class ErrorHandlingMiddleware
    {
        private RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await this._next.Invoke(context);

            context.Response.ContentType = "text/html; charset=utf-8";

            if (context.Response.StatusCode == 403)
            {
                await context.Response.WriteAsync("<h2>Відмовлено в доступі</h2>");
            }
            else if (context.Response.StatusCode == 404)
            {
                await context.Response.WriteAsync("<h2>Не знайдено</h2>");
            }
            else if (context.Response.StatusCode==401)
            {
                await context.Response.WriteAsync("<h2>Помилка аутентифікації<h2>");
            }
        }
    }
}
