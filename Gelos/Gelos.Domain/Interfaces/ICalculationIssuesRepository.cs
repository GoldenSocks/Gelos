using System.Threading.Tasks;

namespace Gelos.Domain.Interfaces
{
    public interface ICalculationIssuesRepository<T> where T: class
    {
         T Get(int id);

         void Add(T issue);

         ICollection<T> GetAll();

         
    }
}