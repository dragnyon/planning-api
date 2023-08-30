using System.Linq.Expressions;
using planning.Entities.Entities;

namespace planning.Repository.Contracts;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    Task<TEntity> Get(Guid id, params Expression<Func<TEntity, object>>[] includeProperties);
    Task<IList<TEntity>> GetAll(params Expression<Func<TEntity, object>>[] includeProperties);
    Task Create(TEntity entity);
    void Update(TEntity entity);
    Task Delete(Guid id);
    Task Save();
}