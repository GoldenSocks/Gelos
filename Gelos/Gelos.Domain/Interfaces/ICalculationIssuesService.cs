using CSharpFunctionalExtensions;
using Gelos.Domain.Models;


namespace Gelos.Domain.Interfaces
{
    public interface ICalculationIssuesService
    {
        public Task<Result> Create(string name, string? description);

        public Task<List<Issue>> Get();

        public Task<Issue?> Get(long id);

        public Task Delete(long id);

        public Task Update(long id);
    }
}
