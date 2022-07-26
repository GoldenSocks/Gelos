using CSharpFunctionalExtensions;
using Gelos.Domain.Interfaces;
using Gelos.Domain.Models;


namespace Gelos.BusinessLogic.Services
{
    public class CalculationIssuesService : ICalculationIssuesService
    {
        private readonly ICalculationIssuesRepository _calculationIssuesRepository;

        public CalculationIssuesService(ICalculationIssuesRepository calculationIssuesRepository)
        {
            _calculationIssuesRepository = calculationIssuesRepository;
        }

        public async Task<Result> Create(string name, string? description)
        {
            var issue = Issue.Create(name, description, DateTime.Now);

            if (issue.Value == null)
            {
                return issue;
            }
            
            await _calculationIssuesRepository.Add(issue.Value);
            return Result.Success();
        }

        public async Task<List<Issue>> Get()
        {
            return await _calculationIssuesRepository.Get();
        }

        public async Task<Issue?> Get(long id)
        {
            var issue = await _calculationIssuesRepository.Get(id);
            return  issue;
        }

        public async Task Delete(long id)
        {
            await _calculationIssuesRepository.Delete(id);
        }

        public async Task Update(long id)
        {
            await _calculationIssuesRepository.Update(id);
        }
    }
}