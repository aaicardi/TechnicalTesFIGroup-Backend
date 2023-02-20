
using TecnicalTest.FIGroup.Domain.Entities;

namespace TecnicalTest.FIGroup.Infrastructure.Interface.IPersistence.IRepositories;

public interface ITasksRepository : IRepository<Tasks>
{
    IEnumerable<Tasks> GetAllTasks();
    Task<Tasks> CreateTasks(Tasks tasks);
    Task<Tasks> UpdateTasks(Tasks tasks);
    Task<Tasks> DeleteTasks(int tasksId);
}

