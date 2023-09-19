using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _0_Framework.Domain;
using MH.DDD.Core.Types;
using TaskManagement.Domain.TaskAgg.ValueObjects;

namespace TaskManagement.Domain.TaskAgg.Entities
{
    

    public class TaskEntity : EntityBase<Guid>
    {
        public Guid Id { get; private set; }
        
        public Guid UserId { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public bool IsCompleted { get; private set; }

        // Define the DueDate property as a navigation property
        public DueDate DueDate { get; private set; }


        private TaskEntity() { } // Private constructor for EF Core

        public TaskEntity(Guid id, string title, string description, DueDate dueDate , Guid userId)
        {
            Id = id;
            Title = title;
            Description = description;
            IsCompleted = false;
            DueDate = dueDate;
            UserId = userId;
        }


        // Methods for changing task state
        public void MarkAsCompleted()
        {
            
            // Guard
            if(this.IsCompleted == true)
                throw ServiceResult.Create<bool>(false).SetError("AlreadyDone").ToException();

            IsCompleted = true;
            
        }

    }

}