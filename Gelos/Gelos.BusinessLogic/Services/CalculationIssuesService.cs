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

        public string Create(string name, string? description)
        {
            var (issue, error) = Issue.Create(name, description, DateTime.Now);

            if (!string.IsNullOrEmpty(error) || issue == null)
            {
                return error;
            }
            
            _calculationIssuesRepository.Add(issue);
            return "Success Create";
        }

        public List<Issue> Get()
        {
            return _calculationIssuesRepository.Get();
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