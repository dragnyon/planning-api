namespace planning.Repository.Contracts;

public interface IRepository<T> where T : class
{
    List<T> GetAll();
    T Get(Guid id);
    void Create(T entity);
}