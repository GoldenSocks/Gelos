namespace Gelos.Domain.Interfaces
{
    public interface IRepository<T>
    {
        Task<T?> GetAsync(long id);

        Task<List<T>> GetAllAsync();

        Task AddAsync(T entity);

        Task<CSharpFunctionalExtensions.Result> UpdateAsync(long id);

        Task DeleteAsync(long id);
    }
}