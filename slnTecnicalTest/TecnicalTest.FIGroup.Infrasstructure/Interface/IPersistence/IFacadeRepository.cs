using TecnicalTest.FIGroup.Infrastructure.Interface.IPersistence.IRepositories;

namespace TecnicalTest.FIGroup.Infrastructure.Interface.IPersistence;

public interface IFacadeRepository : IUnitOfWork
{
    ITasksRepository TasksRepository { get; }
}

