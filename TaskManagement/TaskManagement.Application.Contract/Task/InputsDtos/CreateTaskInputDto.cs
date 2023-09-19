using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagement.Application.Contract.Task.InputsDtos
{
    public class CreateTaskInputDto
    {
        public CreateTaskInputDto()
        {
        }

        public string UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}