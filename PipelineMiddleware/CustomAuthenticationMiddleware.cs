namespace Middleware.PipelineMiddleware
{
    public class CustomAuthenticationMiddleware
    {
        private RequestDelegate _next;

        private string _login;

        private string _password;

        public CustomAuthenticationMiddleware(RequestDelegate next)
        {
            this._next = next;
            this._login = "1234";
            this._password = "4321";
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var login = context.Request.Query["login"];
            var password = context.Request.Query["password"];

            if (login != this._login || password != this._password)
            {
                context.Response.StatusCode = 403;
            }
            else
            {
                await this._next.Invoke(context);

            }
        }
    }
}
