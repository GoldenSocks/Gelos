using Gelos.BusinessLogic.Services;
using Gelos.DataAccess.Json;
using Gelos.DataAccess.Postgres;
using Gelos.DataAccess.Postgres.Repository;
using Gelos.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();


builder.Services.AddScoped<ICalculationIssuesRepository, CalculationIssuesRepository>();
builder.Services.AddScoped<ICalculationIssuesService, CalculationIssuesService>();

builder.Services.AddSingleton<JsonContext>();
builder.Services.AddSingleton(x => new JsonSettings("..\\Gelos.DataAccess.Json\\Data\\"));

builder.Services.AddDbContext<GelosContext>(options => 
{
    options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(GelosContext)));
});

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

public partial class Program { }
