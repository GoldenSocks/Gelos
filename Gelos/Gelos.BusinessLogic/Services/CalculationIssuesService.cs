using Gelos.Domain.Interfaces;
using Gelos.Domain.Models;

namespace Gelos.BusinessLogic.Services
{
    public class CalculationIssuesService : ICalculationIssuesService
    {
        private readonly ICalculationIssuesRepository<Issue> _calculationIssuesRepository;

        public CalculationIssuesService(ICalculationIssuesRepository<Issue> calculationIssuesRepository)
        {
            _calculationIssuesRepository = calculationIssuesRepository;
        }

        public string Create(string name, string? description)
        {
            var (issue, error) = Issue.Create(name, description);

            if (!string.IsNullOrEmpty(error) || issue == null)
            {
                return error;
            }
            _calculationIssuesRepository.Add(issue);
            return "Success";
        }
    }
}