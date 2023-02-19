namespace TecnicalTest.FIGroup.Infrastructure.Interface.IPersistence;

public interface IUnitOfWork : IDisposable
{
    public Task<int> SaveChangesAsync();
}

