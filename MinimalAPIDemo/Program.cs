using Attendence_MinimalAPI;
using DataAccess.DbAccess;
using MovieMateAPI.Dependencies.Configs;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add minimal API + Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Attendance API",
        Version = "v1"
    });
});


//builder.WebHost.ConfigureKestrel(options =>
//{
//    options.ListenAnyIP(5000); // HTTP

//    options.ListenAnyIP(5001, listenOptions =>
//    {
//        listenOptions.UseHttps("/etc/letsencrypt/live/watchdog.lk/cert.pfx", "watchdog5000pw");
//    });
//});





// Register CORS and application services
builder.Services.AddCorsServices();

builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddSingleton<IShiftDataRepo, ShiftDataRepo>();

var app = builder.Build();

// Enable CORS - Must be called before other middleware
app.UseAppCorsConfig();

// Enable HTTPS redirection
//app.UseHttpsRedirection();

// Enable Swagger
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Attendance API V1");
    options.RoutePrefix = "swagger";
});

// Map API routes
app.ConfigureEndpoints();

app.Run();



