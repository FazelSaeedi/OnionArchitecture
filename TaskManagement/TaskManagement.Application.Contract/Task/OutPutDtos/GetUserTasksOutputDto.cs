using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagement.Application.Contract.Task.OutPutDtos
{
    public class GetUserTasksOutputDto
    {
        
        public GetUserTasksOutputDto()
        {
        }

        public string Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreateAt { get; set; }

    }
}