using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MH.DDD.Core.Types;
using TaskManagement.Application.Commands;
using TaskManagement.Application.Contract.Task;
using TaskManagement.Application.Contract.Task.InputsDtos;
using TaskManagement.Application.Contract.Task.OutPutDtos;

namespace TaskManagement.Application
{
    public class TaskApplication : ITaskApplication
    {
        public IMediator _mediator { get; set; }
        public TaskApplication(IMediator mediator)
        {
            _mediator = mediator;
        }

        public List<GetUserTasksOutputDto> GetUserTasks()
        {
            throw new NotImplementedException();
        }

        async Task<ServiceResult<string>> ITaskApplication.CreateTask(CreateTaskInputDto createTaskInputDto)
        {
            return await _mediator.Send(new CreateTaskCommand(createTaskInputDto));
        }
    }
}