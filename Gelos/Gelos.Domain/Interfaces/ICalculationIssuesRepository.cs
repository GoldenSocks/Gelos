using Gelos.Domain.Interfaces;
using Gelos.Domain.Models;

namespace Gelos.Domain.Interfaces
{
    public interface ICalculationIssuesRepository<T> where T : class
    {
        T Get(int id);

        List<T> GetAll();

        void Add(T obj);

        void Update(T obj);

        void Delete(int id);
    }
}