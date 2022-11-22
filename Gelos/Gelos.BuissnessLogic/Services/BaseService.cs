using Gelos.Domain.Interfaces;

namespace Gelos.BusinessLogic.Services
{
    public class BaseService<T> : IService<T>
    {
        protected readonly IRepository<T> _repository;

        internal BaseService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<List<T>> GetAll()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<T?> Get(long id)
        {
            var model = await _repository.GetAsync(id);
            return model;
        }

        public async Task Delete(long id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task Update(long id)
        {
            await _repository.UpdateAsync(id);
        }

    }
}
