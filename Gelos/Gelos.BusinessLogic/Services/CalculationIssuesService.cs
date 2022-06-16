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

        public (bool, string) Create(string name, string? description)
        {
            var (issue, error) = Issue.Create(name, description, DateTime.Now);

            if (!string.IsNullOrEmpty(error) || issue == null)
            {
                return (false, error);
            }
            
            _calculationIssuesRepository.Add(issue);
            return (true, String.Empty);
        }

        public List<Issue> Get()
        {
            return _calculationIssuesRepository.Get();
        }

        public Issue? Get(int id)
        {
            var (issue, IsSuccess) = _calculationIssuesRepository.Get(id);
                       
            return  IsSuccess ? issue : null;
        }

        public bool Delete(int id)
        {
            return _calculationIssuesRepository.Delete(id);
        }

        public bool Update(int id)
        {
            return _calculationIssuesRepository.Update(id);
        }
    }
}