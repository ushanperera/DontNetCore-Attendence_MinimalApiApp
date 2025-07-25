using Attendence_MinimalAPI;
using DataAccess.DbAccess;
using MovieMateAPI.Dependencies.Configs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCoresServises();

//Add Application Servises
builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
//builder.Services.AddSingleton<IUserData, UserData>();
builder.Services.AddSingleton<IShiftDataRepo, ShiftDataRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.ConfigureEndpoints();
app.UseAppCoresConfig();


app.Run();
