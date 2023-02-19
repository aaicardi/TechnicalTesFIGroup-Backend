
using TecnicalTest.FIGroup.Infrastructure.Interface.IPersistence;
using TecnicalTest.FIGroup.Infrastructure.Interface.IPersistence.IRepositories;
using TecnicalTest.FIGroup.Infrastructure.Persistence.Repositories;

namespace TecnicalTest.FIGroup.Infrastructure.Persistence;

public class FacadeRepository : UnitOfWork, IFacadeRepository
{
    public FacadeRepository(FIGroupDBContext context) : base(context)
    {
        TasksRepository = new TasksRepository(context);
    }

   public  ITasksRepository TasksRepository { get; }
}

