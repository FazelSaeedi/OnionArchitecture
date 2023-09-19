using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MH.DDD.Core.Types;
using TaskManagement.Application.Contract.Task.InputsDtos;
using TaskManagement.Application.Contract.Task.OutPutDtos;

namespace TaskManagement.Application.Contract.Task
{
    public interface ITaskApplication
    {
        
        List<GetUserTasksOutputDto> GetUserTasks();

        Task<ServiceResult<string>> CreateTask(CreateTaskInputDto createTaskInputDto);
        
    }
}