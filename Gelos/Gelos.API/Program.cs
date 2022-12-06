using System.Reflection;
using Gelos.API.Controllers;
using Gelos.BusinessLogic.Features;
using Gelos.BusinessLogic.Features.Employee;
using Gelos.DataAccess.Postgres;
using Gelos.DataAccess.Postgres.Repository;
using Gelos.Domain.CQS;
using Gelos.Domain.Interfaces;
using Gelos.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();


builder.Services.AddScoped<ICalculationIssuesRepository, CalculationIssuesRepository>();
builder.Services.AddScoped<IRepository<Employee>, EmployeeRepository>();

builder.Services.AddMediatR(typeof(IMediatR).GetTypeInfo().Assembly);
//builder.Services.AddMediatR(typeof(CreateIssueCommandHandler));

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
