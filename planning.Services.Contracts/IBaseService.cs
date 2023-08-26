using System.Linq.Expressions;
using planning.Entities.Entities;
using planning.Repository.Contracts;

namespace planning.Services.Contracts;

public interface IBaseService<TEntity, TRepository>
    where TEntity : BaseEntity
    where TRepository : IBaseRepository<TEntity>
{
    Task<TEntity> Get(Guid id);
    
    Task<IList<TEntity>> GetAll();
    
    Task Create(TEntity entity);
    
    Task Update(TEntity entity);
    
    Task Delete(Guid id);
}