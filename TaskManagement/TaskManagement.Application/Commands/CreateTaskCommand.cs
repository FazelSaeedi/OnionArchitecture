using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _0_Framework.Domain;
using MediatR;
using MH.DDD.Core.Types;
using TaskManagement.Application.Contract.Task.InputsDtos;
using TaskManagement.Domain.TaskAgg.Entities;
using TaskManagement.Domain.TaskAgg.Repository;
using TaskManagement.Domain.TaskAgg.ValueObjects;

namespace TaskManagement.Application.Commands
{
    public class CreateTaskCommand : IRequest<ServiceResult<string>>
    {
        public readonly CreateTaskInputDto createTaskInputDto;

        
        // Repository
        public CreateTaskCommand(CreateTaskInputDto createTaskInputDto )
        {
            this.createTaskInputDto = createTaskInputDto;
        }
    }

    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, ServiceResult<string>>
    {
        private readonly ITaskRepository _taskRepository;

        public CreateTaskCommandHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<ServiceResult<string>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            
            _taskRepository.Create(new TaskEntity(Guid.NewGuid(), request.createTaskInputDto.Title , request.createTaskInputDto.Description , new DueDate(DateTime.UtcNow.AddDays(1)) , Guid.NewGuid()));
            await _taskRepository.SaveChangesAsync();
            
            return ServiceResult.Create<string>("Ok");
        }
    }


}