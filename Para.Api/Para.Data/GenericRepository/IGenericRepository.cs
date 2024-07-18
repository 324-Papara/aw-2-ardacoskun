using System.Linq.Expressions;

namespace Para.Data.GenericRepository;

public interface IGenericRepository<TEntity> where TEntity : class
{
    Task Save();
    Task<List<TEntity>> GetAll();
    Task<List<TEntity>> GetAllWithIncludeAsync(params Expression<Func<TEntity, object>>[] includes);
    Task<TEntity?> GetById(long Id);
    Task<TEntity?> GetWithIncludeByIdAsync(long Id, params Expression<Func<TEntity, object>>[] includes);
    Task<List<TEntity>> Where(Expression<Func<TEntity, bool>> predicate);
    IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includes);
    Task Insert(TEntity entity);
    Task Update(TEntity entity);
    Task Delete(TEntity entity);
    Task Delete(long Id);

}