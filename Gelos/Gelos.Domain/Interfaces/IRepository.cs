using CSharpFunctionalExtensions;
using Gelos.Domain.Models;


namespace Gelos.Domain.Interfaces
{
    public interface IRepository<T>
    {
        Task<T?> GetAsync(long id);

        Task<List<T>> GetAllAsync();

        Task AddAsync(T entity);

        Task<Result> UpdateAsync(long id);

        Task DeleteAsync(long id);
    }
}