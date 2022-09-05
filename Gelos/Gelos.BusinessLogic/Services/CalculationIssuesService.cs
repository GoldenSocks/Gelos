using CSharpFunctionalExtensions;
using Gelos.Domain.Interfaces;
using Gelos.Domain.Models;


namespace Gelos.BusinessLogic.Services
{
    public class CalculationIssuesService : BaseService<Issue>, ICalculationIssuesService
    {
        public CalculationIssuesService(IRepository<Issue> calculationIssuesRepository) : base(calculationIssuesRepository)
        {
        }

        public async Task<Result> Create(string name, string? description)
        {
            var issue = Issue.Create(name, description, DateTime.Now);
            if(issue.IsSuccess)
                await _Repository.AddAsync(issue.Value);
            return issue;
        }

    }
}