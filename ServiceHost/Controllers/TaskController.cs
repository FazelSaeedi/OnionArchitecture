using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _0_Framework.Application.ZarinPal;
using MH.DDD.Core.Types;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Contract.Task;
using TaskManagement.Application.Contract.Task.InputsDtos;

namespace ServiceHost.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : BaseController
    {
        private readonly ILogger<TestController> _logger;
        private readonly ITaskApplication _taskApplication;

        public TaskController(ILogger<TestController> logger, ITaskApplication taskApplication) : base(logger)
        {
            _taskApplication = taskApplication;
        }

        [HttpPost("create")]
        public async Task<ServiceResult<string>> CreateTask(CreateTaskInputDto createTaskInputDto)
        {
            var result = await _taskApplication.CreateTask(createTaskInputDto);
            return result ;
        }
    }
}