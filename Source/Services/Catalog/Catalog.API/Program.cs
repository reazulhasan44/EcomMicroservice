var builder = WebApplication.CreateBuilder(args);

// carter configuration
builder.Services.AddCarter();

// mediatr configuration
var assmebly = typeof(Program).Assembly;
builder.Services.AddMediatR(config => {
    config.RegisterServicesFromAssembly(assmebly);
});



var app = builder.Build();

app.MapCarter();

app.Run();
