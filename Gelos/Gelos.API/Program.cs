//using Gelos.DataAccess.Json;

using Gelos.BusinessLogic.Services;
using Gelos.DataAccess.Postgres;
using Gelos.DataAccess.Postgres.Repository;
using Gelos.Domain.Interfaces;
using Gelos.Domain.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();


builder.Services.AddScoped<IRepository<Issue>, CalculationIssuesRepository>();
builder.Services.AddScoped<IRepository<Employee>, EmployeeRepository>();
builder.Services.AddScoped<ICalculationIssuesService, CalculationIssuesService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

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
