using CSharpFunctionalExtensions;
using Gelos.DataAccess.Postgres.Entities;
using Gelos.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gelos.DataAccess.Postgres.Repository
{
    public abstract class BaseRepository<TModel, TEntity> : IRepository<TModel>
        where TEntity : BaseEntity 
        where TModel : class
    {
        private readonly DbContext _context;
        protected DbContext Context => _context;
        protected abstract Result<TModel> CreateModel(TEntity entity);
        protected abstract TEntity CreateEntityInstance(TModel model);

        protected BaseRepository(DbContext context)
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

            if (entity == null)
            {
                return null;
            }
            var model = CreateModel(entity);
            
            return model.IsSuccess ? 
                model.Value : null;
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

            if (!model.IsCompletedSuccessfully || model.Result is null)
            {
                return Result.Failure("Id is not valid");
            } 
            
            _context.Update(CreateEntityInstance(model.Result));
            await _context.SaveChangesAsync();
            return Result.Success();
        }
    }
}
