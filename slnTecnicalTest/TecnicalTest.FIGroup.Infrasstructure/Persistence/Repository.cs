using Microsoft.EntityFrameworkCore;

using TecnicalTest.FIGroup.Infrastructure.Interface.IPersistence;

namespace TecnicalTest.FIGroup.Infrastructure.Persistence;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly DbSet<T> _entities;

    public Repository(DbContext context)
    {
        _entities = context.Set<T>();
    }

    public IQueryable<T?> GetAll()
    {
        return _entities.AsQueryable();
    }

    public async Task<T?> GetByIdAsync(long id)
    {
        return (await _entities.FindAsync(id))!;
    }

    public async Task AddAsync(T entity)
    {
        await _entities.AddAsync(entity);
    }

    public void Remove(T entity)
    {
        _entities.Remove(entity);
    }

    public void RemoveRange(List<T> entity)
    {
        _entities.RemoveRange(entity);
    }
}

