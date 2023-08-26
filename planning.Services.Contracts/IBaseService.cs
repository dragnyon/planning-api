using System.Linq.Expressions;
using planning.Entities.Entities;
using planning.Repository.Contracts;

namespace planning.Services.Contracts;

public interface IBaseService<TEntity, TRepository>
    where TEntity : BaseEntity
    where TRepository : IBaseRepository<TEntity>
{
    Task<TEntity> Get(Guid id, params Expression<Func<TEntity, object>>[] includeProperties);
    
    Task<IList<TEntity>> GetAll(params Expression<Func<TEntity, object>>[] includeProperties);
    
    Task Create(TEntity entity);
    
    Task Update(TEntity entity);
    
    Task Delete(Guid id);
}