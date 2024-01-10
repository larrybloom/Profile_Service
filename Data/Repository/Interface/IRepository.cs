namespace ProfileService.Data.Repository.Interface
{
    public interface IRepository<TEntity>
    {
        Task<IQueryable<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(string id);
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task DeleteRangeAsync(IEnumerable<TEntity> entities);
        Task<IQueryable<TEntity>> GetAllAsync2();
    }
}
