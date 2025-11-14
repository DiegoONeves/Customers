using Application.Features;
using Application.Features.Customers.Commands;
using Infra.IoC;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddEndpointsApiExplorer(); // gera metadados pros endpoints        
builder.Services.AddInfrastructure();

var app = builder.Build();


app.UseHttpsRedirection();

// Endpoints
app.MapPost("/Customers", async (CreateCustomerCommand command, IDispatcher dispatcher) =>
{
    var result = await dispatcher.DispatchCommand<CreateCustomerCommand, Result<Guid>>(command);
    return result.IsSuccess ? Results.Ok(result.Value) : Results.BadRequest(result.Error);
})
.WithName("CreateCustomer")
.WithOpenApi(); // adiciona no Swagger automaticamente

app.Run();