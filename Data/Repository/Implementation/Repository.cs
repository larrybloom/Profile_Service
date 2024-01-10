using Microsoft.EntityFrameworkCore;
using ProfileService.Data.Repository.Interface;

namespace ProfileService.Data.Repository.Implementation
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly InvestDataContext _investDataContext;

        public Repository(InvestDataContext investDataContext)
        {
            _investDataContext = investDataContext;
        }

        public async Task AddAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _investDataContext.Set<TEntity>().AddAsync(entity);
            await _investDataContext.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            await _investDataContext.Set<TEntity>().AddRangeAsync(entities);
            await _investDataContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _investDataContext.Set<TEntity>().Remove(entity);
            await _investDataContext.SaveChangesAsync();
        }

        public async Task DeleteRangeAsync(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            _investDataContext.Set<TEntity>().RemoveRange(entities);
            await _investDataContext.SaveChangesAsync();
        }

        public Task<IQueryable<TEntity>> GetAllAsync()
        {
            return Task.Run(() => _investDataContext.Set<TEntity>().AsQueryable());

        }

        public async Task<IQueryable<TEntity>> GetAllAsync2()
        {
            var result = await _investDataContext.Set<TEntity>().ToListAsync();
            return result.AsQueryable();
        }

        public async Task<TEntity?> GetByIdAsync(string id)
        {
            return await _investDataContext.Set<TEntity>().FindAsync(id);

        }

        public async Task UpdateAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _investDataContext.Set<TEntity>().Update(entity);
            await _investDataContext.SaveChangesAsync();
        }
    }
}
