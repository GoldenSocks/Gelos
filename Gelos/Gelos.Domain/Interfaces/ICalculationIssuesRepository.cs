using CSharpFunctionalExtensions;
using Gelos.Domain.Models;


namespace Gelos.Domain.Interfaces
{
    public interface ICalculationIssuesRepository
    {
        Task<Issue?> Get(long issueId);

        Task<List<Issue>> Get();

        Task Add(Issue issue);

        Task<Result> Update(long issueId);

        Task Delete(long issueId);
    }
}