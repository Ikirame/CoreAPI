namespace Api.OpenApi;

public static class OpenApiExtensions
{
    public static void MapOpenApi(this WebApplication app)
    {
        app.UseSwaggerUI(options =>
        {
            options.RoutePrefix = "openapi";
            options.SwaggerEndpoint("/openapi/v1.json", "v1");
        });
    }
}