
using TecnicalTest.FIGroup.Domain.Entities;

namespace TecnicalTest.FIGroup.Infrastructure.Interface.IPersistence.IRepositories;

public interface ITasksRepository : IRepository<Tasks>
{
    public IEnumerable<Tasks> GetAllTasks();
}

