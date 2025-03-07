var builder = WebApplication.CreateBuilder(args);

// carter configuration
builder.Services.AddCarter();

// mediatr configuration
var assmebly = typeof(Program).Assembly;
builder.Services.AddMediatR(config => {
    config.RegisterServicesFromAssembly(assmebly);
});

// marten configuration
builder.Services.AddMarten(opts => {
    opts.Connection(builder.Configuration.GetConnectionString("Database"));
}).UseLightweightSessions();


var app = builder.Build();

app.MapCarter();

app.Run();
