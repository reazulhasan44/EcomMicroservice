using BuildingBlocks.Behaviors;
using BuildingBlocks.Exceptions.Handler;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);



// mediatr configuration
var assmebly = typeof(Program).Assembly;
builder.Services.AddMediatR(config => {
    config.RegisterServicesFromAssembly(assmebly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});

// fluent validation configuration register all validation 
builder.Services.AddValidatorsFromAssembly(assmebly);


// carter configuration
builder.Services.AddCarter();

// marten configuration
builder.Services.AddMarten(opts => {
    opts.Connection(builder.Configuration.GetConnectionString("Database"));
}).UseLightweightSessions();

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

var app = builder.Build();

app.MapCarter();

app.UseExceptionHandler(options => { });

app.Run();
