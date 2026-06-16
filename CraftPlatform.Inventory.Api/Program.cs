using CraftPlatform.Inventory.Api.EndPoints.Categories.Create;
using CraftPlatform.Inventory.Api.EndPoints.Categories.Delete;
using CraftPlatform.Inventory.Api.EndPoints.Categories.Read;
using CraftPlatform.Inventory.Api.EndPoints.Categories.ReadById;
using CraftPlatform.Inventory.Api.EndPoints.Categories.Update;
using CraftPlatform.Inventory.Infrastructure;
using CraftPlatform.Inventory.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer(); // Required for Swagger
builder.Services.AddSwaggerGen(); // Add Swagger generation



builder.Services.AddInfrastructureLayer(builder.Configuration);
builder.Services.AddServiceLayerDependencies();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Enable Swagger
    app.UseSwaggerUI(); // Enable Swagger UI
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// map endpoints
app.MapCategoriesCreateEndPoint();
app.MapCategoriesReadEndpoint();
app.MapCategoriesReadByIdEndpoint();
app.MapCategoriesDeleteEndpoint();
app.MapCategoriesUpdateEndpoint();

app.Run();
