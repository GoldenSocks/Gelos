using Gelos.Domain.Models;


namespace Gelos.Domain.Interfaces
{
    public interface ICalculationIssuesRepository
    {
        Issue Get(int id);

        List<Issue> Get();

        void Add(Issue issue);

        void Update(Issue issue);

        void Delete(int id);
    }
}