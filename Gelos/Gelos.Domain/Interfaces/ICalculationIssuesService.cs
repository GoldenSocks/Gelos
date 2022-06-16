using Gelos.Domain.Models;


namespace Gelos.Domain.Interfaces
{
    public interface ICalculationIssuesService
    {
        public (bool, string) Create(string name, string? description);

        public List<Issue> Get();

        public Issue? Get(int id);

        public bool Delete(int id);

        public bool Update(int id);
    }
}
