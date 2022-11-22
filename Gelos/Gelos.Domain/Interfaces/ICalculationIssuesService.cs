using Gelos.Domain.Models;


namespace Gelos.Domain.Interfaces
{
    public interface ICalculationIssuesService : IService<Issue>
    {
        public Task<CSharpFunctionalExtensions.Result> Create(string name, string? description);
    }
}
