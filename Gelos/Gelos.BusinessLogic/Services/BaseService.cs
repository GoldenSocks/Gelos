using Gelos.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gelos.BusinessLogic.Services
{
    public class BaseService<T> : IService<T>
    {
        protected readonly IRepository<T> _Repository;

        public BaseService(IRepository<T> repository)
        {
            _Repository = repository;
        }

        public async Task<List<T>> GetAll()
        {
            return await _Repository.GetAllAsync();
        }

        public async Task<T?> Get(long id)
        {
            var model = await _Repository.GetAsync(id);
            return model;
        }

        public async Task Delete(long id)
        {
            await _Repository.DeleteAsync(id);
        }

        public async Task Update(long id)
        {
            await _Repository.UpdateAsync(id);
        }

    }
}
