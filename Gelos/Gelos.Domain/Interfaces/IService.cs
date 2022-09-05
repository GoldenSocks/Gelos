using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gelos.Domain.Interfaces
{
    public interface IService<T>
    {
        public Task<List<T>> GetAll();

        public Task<T?> Get(long id);

        public Task Delete(long id);

        public Task Update(long id);

    }
}
