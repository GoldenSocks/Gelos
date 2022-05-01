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
            var (issue, error) = Issue.Create(name, description, DateTime.Now);

            if (!string.IsNullOrEmpty(error) || issue == null)
            {
                return error;
            }
            
            // Легко могут быть повторяющиеся Id
            var issueId = _calculationIssuesRepository.GetAll().Count + 1;

            _calculationIssuesRepository.Add(issue with { Id = issueId });
            return "Success Create";
        }

        public List<Issue> GetAll()
        {
            return _calculationIssuesRepository.GetAll();
        }

        public Issue Get(int id)
        {
            return _calculationIssuesRepository.Get(id);
        }

        public string Delete(int id)
        {
            _calculationIssuesRepository.Delete(id);
            return "Success Delete";
        }
    }
}