using System.Text.Json;
using System.Text.Json.Serialization;
using Api.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers(options => { options.Filters.Add<ErrorHandlingFilterAttribute>(); })
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapStaticAssets();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();