using MarsRover.Interfaces;
using MarsRover.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Dependency injection
builder.Services.AddSingleton<IValidationService, ValidationService>();
builder.Services.AddSingleton<IMovementService, MovementService>();

var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
