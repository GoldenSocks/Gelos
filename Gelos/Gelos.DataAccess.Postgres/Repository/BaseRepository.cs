using CSharpFunctionalExtensions;
using Gelos.DataAccess.Postgres.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gelos.DataAccess.Postgres.Repository
{
    public abstract class BaseRepository<TModel, TEntity> where TEntity : BaseEntity where TModel : class
    {

        protected readonly GelosContext _context;

        public BaseRepository(GelosContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TModel model)
        {
            var instance = CreateEntityInstance(model);
            await _context.AddAsync(instance);
            await _context.SaveChangesAsync();
        }


        public async Task DeleteAsync(long id)
        {
            var entity = _context.Set<TEntity>().FindAsync(id);
            if (entity.IsCompletedSuccessfully)
            {
                _context.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }


        public async Task<TModel?> GetAsync(long id)
        {
            var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(entity => entity.Id == id);

            if (entity != null)
            {
                var model = CreateModel(entity);
                if (model.IsSuccess)
                {
                    return model.Value;
                }
            }
            return null;
        }

        public async Task<List<TModel>> GetAllAsync()
        {
            var entities = await _context.Set<TEntity>().ToListAsync();

            var models = new List<TModel>();

            foreach (var entity in entities)
            {
                var model = CreateModel(entity);
                if (model.IsSuccess)
                {
                    models.Add(model.Value);
                }
            }
            return models;
        }

        public async Task<Result> UpdateAsync(long id)
        {
            var model = GetAsync(id);

            if (model.IsCompletedSuccessfully && model.Result is not null)
            {
                _context.Update(CreateEntityInstance(model.Result));
                await _context.SaveChangesAsync();
                return Result.Success();
            }

            return Result.Failure("Id is not valid");
        }

        protected abstract Result<TModel> CreateModel(TEntity entity);
        protected abstract TEntity CreateEntityInstance(TModel model);





    }
}
