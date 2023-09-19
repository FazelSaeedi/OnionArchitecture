using _0_Framework.Domain;
using TaskManagement.Domain.TaskAgg.Entities;

namespace TaskManagement.Domain.TaskAgg.Repository;

public interface ITaskRepository 
{
    void Create(TaskEntity entity);
    Task SaveChangesAsync();

}
