using Gelos.BusinessLogic.Services;
using Gelos.DataAccess.Json;
using Gelos.DataAccess.Json.Repository;
using Gelos.Domain.Interfaces;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();


builder.Services.AddScoped<ICalculationIssuesRepository, CalculationIssuesRepository>();
builder.Services.AddScoped<ICalculationIssuesService, CalculationIssuesService>();
builder.Services.AddSingleton<JsonContext>();


builder.Services.AddSingleton(x => new JsonSettings("..\\Gelos.DataAccess.Json\\Data\\"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
