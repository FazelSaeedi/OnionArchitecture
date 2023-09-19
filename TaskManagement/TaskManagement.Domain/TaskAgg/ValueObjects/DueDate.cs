using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _0_Framework.Domain;

namespace TaskManagement.Domain.TaskAgg.ValueObjects
{
    public class DueDate : ValueObjectBase
    {
        public DateTime Value { get; private set; }

        private DueDate() { } // Private constructor for EF Core

        public DueDate(DateTime value)
        {

            if (value < DateTime.UtcNow)
            {
                throw new ArgumentException("Due date cannot be in the past.");
            }

            Value = value;
        }
    }
}