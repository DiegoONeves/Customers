using Application.Features.Customers.Commands;
using Application.Features.Customers.Handlers;
using Infra.IoC;

var builder = WebApplication.CreateBuilder(args);

var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{env}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables(); // libera override por env vars

// Services
builder.Services.AddEndpointsApiExplorer(); // gera metadados pros endpoints        
builder.Services.AddServices(builder.Configuration);

var app = builder.Build();


app.UseHttpsRedirection();

// Endpoints
app.MapPost("/customers", async (CreateCustomerCommand command, CreateCustomerCommandHandler handler) =>
{
    var result = await handler.Handle(command);
    return result.IsSuccess ? Results.Ok(result.Value) : Results.BadRequest(result.Error);
})
.WithName("CreateCustomer")
.WithOpenApi(); // adiciona no Swagger automaticamente

app.Run();