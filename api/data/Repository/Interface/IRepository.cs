namespace data.Repository.Interface;

public interface IRepository<T> where T : class
{
    Task AddEntity(T entity);
    Task UpdateEntity(T entity);
}