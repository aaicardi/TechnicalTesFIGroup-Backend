
using TecnicalTest.FIGroup.Infrastructure.Interface.IPersistence;

namespace TecnicalTest.FIGroup.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    protected readonly FIGroupDBContext Context;

    protected UnitOfWork(FIGroupDBContext context)
    {
        Context = context;

    }

    public async Task<int> SaveChangesAsync()
    {
        return await Context.SaveChangesAsync();
    }

    public void Dispose()
    {
        Context.Dispose();
        GC.SuppressFinalize(this);
    }

}

