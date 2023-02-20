
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
        var resul = _dbContext.Task.AsQueryable().Where(x => x.Status.Equals(true));
        return resul;
    }

    public async Task<Tasks> CreateTasks(Tasks tasks)
    {
        _dbContext.Set<Tasks>().Add(tasks);
        await _dbContext.SaveChangesAsync();
        return tasks;
    }

    public async Task<Tasks> UpdateTasks(Tasks tasks)
    {
         tasks.Status = true;
        _dbContext.Task.Update(tasks);
        await _dbContext.SaveChangesAsync();
        return tasks;
    }

    public async Task<Tasks> DeleteTasks(int tasksId)
    {
        var result = _dbContext.Task.FirstOrDefault(x => x.Id.Equals(tasksId) && x.Status.Equals(true));
        if (result != null)
        {
            result.Status = false;
            _dbContext.Task.Update(result);
            await _dbContext.SaveChangesAsync();
            return result;
        }
        return new Tasks();
    }

}

