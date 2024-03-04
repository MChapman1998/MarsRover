using MarsRover.Interfaces;
using MarsRover.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Dependency injection
builder.Services.AddSingleton<IValidationService, ValidationService>();
builder.Services.AddSingleton<IMovementService, MovementService>();
builder.Services.AddSingleton<INorthMovement, NorthMovement>();
builder.Services.AddSingleton<ISouthMovement, SouthMovement>();
builder.Services.AddSingleton<IWestMovement, WestMovement>();
builder.Services.AddSingleton<IEastMovement, EastMovement>();

var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
