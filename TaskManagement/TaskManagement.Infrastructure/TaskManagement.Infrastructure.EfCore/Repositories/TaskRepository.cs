using TaskManagement.Domain.TaskAgg.Entities;
using TaskManagement.Domain.TaskAgg.Repository;

namespace TaskManagement.Infrastructure.EfCore.Repositories;

public class TaskRepository : ITaskRepository
{
    public TaskContext _taskContext { get; set; }
    
    public TaskRepository(TaskContext taskContext)
    {
        _taskContext = taskContext;
    }

    public void Create(TaskEntity entity)
    {
        _taskContext.Add(entity);
    }

    public async Task SaveChangesAsync()
    {
        await _taskContext.SaveChangesAsync();
    }
}