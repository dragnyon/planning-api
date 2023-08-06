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

    public async Task<TEntity> Get(Guid id)
    {
        return await _repository.Get(id);
    }

    public async Task<IList<TEntity>> GetAll()
    {
        return await _repository.GetAll();
    }

    public async Task Create(TEntity entity)
    {
        await _repository.Create(entity);
        await _repository.Save();
    }

    public void Update(TEntity entity)
    {
        _repository.Update(entity);
    }

    public async Task Delete(Guid id)
    {
        await _repository.Delete(id);
        await _repository.Save();
    }
}