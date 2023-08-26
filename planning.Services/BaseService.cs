using System.Linq.Expressions;
using planning.Entities.Entities;
using planning.Repository.Contracts;
using planning.Services.Contracts;

namespace planning.Services;

public class BaseService<TEntity, TRepository> : IBaseService<TEntity, TRepository>
    where TEntity : BaseEntity
    where TRepository : IBaseRepository<TEntity>
{
    private readonly TRepository _repository;
    private readonly List<Expression<Func<TEntity, object>>> _includes;

    protected BaseService(TRepository repository, List<Expression<Func<TEntity, object>>> includes)
    {
        _repository = repository;
        _includes = includes;
    }

    public async Task<TEntity> Get(Guid id)
    {
        return await _repository.Get(id, _includes.ToArray());
    }

    public async Task<IList<TEntity>> GetAll()
    {
        return await _repository.GetAll(_includes.ToArray());
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