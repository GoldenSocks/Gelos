using Gelos.Domain.Models;


namespace Gelos.Domain.Interfaces
{
    public interface ICalculationIssuesRepository
    {
        (Issue?, bool) Get(int id);

        List<Issue> Get();

        void Add(Issue issue);

        bool Update(int id);

        bool Delete(int id);
    }
}