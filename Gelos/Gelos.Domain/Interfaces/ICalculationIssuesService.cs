using CSharpFunctionalExtensions;
using Gelos.Domain.Models;


namespace Gelos.Domain.Interfaces
{
    public interface ICalculationIssuesService : IService<Issue>
    {
        public Task<Result> Create(string name, string? description);

    }
}
