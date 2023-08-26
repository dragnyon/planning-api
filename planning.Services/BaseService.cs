using System.Linq.Expressions;
using planning.Entities.Entities;
using planning.Repository.Contracts;
using planning.Services.Contracts;

namespace planning.Services;

public class BaseService<TEntity, TRepository> : IBaseService<TEntity, TRepository>
    where TEntity : BaseEntity
    where TRepository : IBaseRepository<TEntity>
{
    protected readonly TRepository _repository;

    protected BaseService(TRepository repository)
    {
        _repository = repository;
    }

    public async Task<TEntity> Get(Guid id, params Expression<Func<TEntity, object>>[] includeProperties)
    {
        return await _repository.Get(id, includeProperties);
    }

    public async Task<IList<TEntity>> GetAll(params Expression<Func<TEntity, object>>[] includeProperties)
    {
        return await _repository.GetAll(includeProperties);
    }

    public async Task Create(TEntity entity)
    {
        await _repository.Create(entity);
        await _repository.Save();
    }

    public async Task Update(TEntity entity)
    {
        _repository.Update(entity);
        await _repository.Save();
    }

    public async Task Delete(Guid id)
    {
        await _repository.Delete(id);
        await _repository.Save();
    }
}