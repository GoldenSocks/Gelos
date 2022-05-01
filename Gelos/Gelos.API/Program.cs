using Gelos.BusinessLogic.Services;
using Gelos.DataAccess.Json;
using Gelos.DataAccess.Json.Repository;
using Gelos.Domain.Interfaces;
using Gelos.Domain.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();


builder.Services.AddTransient<ICalculationIssuesRepository<Issue>, CalculationIssuesRepository>();
builder.Services.AddTransient<ICalculationIssuesService, CalculationIssuesService>();
builder.Services.AddTransient<JsonContext>();


builder.Services.AddSingleton(x => new JsonSettings("..\\Gelos.DataAccess.Json\\Data\\data.json"));

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
