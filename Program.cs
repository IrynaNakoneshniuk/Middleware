using PipelineCustomMiddleware.PipelineMiddleware;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("Error");
    app.UseHsts();
}


app.UseErrorHandling();
app.UseCustomAuthentication();
app.UseCustomRouting();


app.Run();
