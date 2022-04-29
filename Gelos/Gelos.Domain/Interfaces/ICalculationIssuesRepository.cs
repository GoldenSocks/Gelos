using Gelos.Domain.Interfaces;
using Gelos.Domain.Models;

namespace Gelos.Domain.Interfaces
{
    public interface ICalculationIssuesRepository<T> where T : class
    {
        Issue Get(int id);

        void Add(Issue obj);

        void Update(Issue obj);

        void Delete(int id);
    }
}