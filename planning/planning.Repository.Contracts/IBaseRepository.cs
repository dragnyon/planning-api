using planning.Entities;

namespace planning.Repository.Contracts;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    Task<TEntity> Get(Guid id);
    Task<IList<TEntity>> GetAll();
    Task Create(TEntity entity);
    void Update(TEntity entity);
    Task Delete(Guid id);
    Task Save();
}