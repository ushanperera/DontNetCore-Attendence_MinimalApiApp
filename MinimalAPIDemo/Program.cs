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

// Register CORS and application services
builder.Services.AddCorsServices();

builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddSingleton<IShiftDataRepo, ShiftDataRepo>();

var app = builder.Build();
//app.UseHttpsRedirection();

// Enable Swagger (even in production)
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Attendance API V1");
    options.RoutePrefix = "swagger"; // Available at /swagger
});

// Enable CORS
app.UseAppCorsConfig();

// Map API routes
app.ConfigureEndpoints();

// ✅ Make sure the app listens on all IPs, not just localhost
//app.Run();
app.Run("http://0.0.0.0:5000");



