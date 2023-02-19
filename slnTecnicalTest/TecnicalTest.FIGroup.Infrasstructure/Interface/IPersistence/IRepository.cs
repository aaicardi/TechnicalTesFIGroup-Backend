namespace TecnicalTest.FIGroup.Infrastructure.Interface.IPersistence;

public interface IRepository<T> where T : class
{
    IQueryable<T?> GetAll();
    Task<T?> GetByIdAsync(long id);
    Task AddAsync(T entity);
    void Remove(T entity);
    void RemoveRange(List<T> entity);
}

