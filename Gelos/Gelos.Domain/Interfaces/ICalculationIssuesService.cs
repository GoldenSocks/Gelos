using Gelos.Domain.Models;


namespace Gelos.Domain.Interfaces
{
    public interface ICalculationIssuesService
    {
        public string Create(string name, string? description);

        public List<Issue> GetAll();

        public Issue Get(int id);

        public string Delete(int id);
    }
}
