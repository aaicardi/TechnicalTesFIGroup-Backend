
using TecnicalTest.FIGroup.Domain.Entities;
using TecnicalTest.FIGroup.Infrastructure.Interface.IPersistence.IRepositories;

namespace TecnicalTest.FIGroup.Infrastructure.Persistence.Repositories;

public class TasksRepository : Repository<Tasks>, ITasksRepository
{
    private readonly FIGroupDBContext _dbContext;

    public TasksRepository(FIGroupDBContext context) : base(context)
    {
        _dbContext = context;
    }

    public IEnumerable<Tasks> GetAllTasks()
    {
        var resul = _dbContext.Task.AsQueryable();
        return resul;
    }
}

