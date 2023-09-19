using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.TaskAgg.Entities;
using TaskManagement.Infrastructure.EfCore.Mappings;

namespace TaskManagement.Infrastructure.EfCore
{
    public class TaskContext : DbContext
    {
        public DbSet<TaskEntity> Articles { get; set; }

        
        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {
        }

        
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // { 
        //     optionsBuilder.UseSqlServer(@"Server=localhost,1433; Database=Base.DB;User id=sa; Password=Pass@word;");
        // }
        
        public TaskContext()
        {
        }



        // PS F:\Projects\Custom_Base\TaskManagement\TaskManagement.Infrastructure\TaskManagement.Infrastructure.EfCore> dotnet ef migrations add init --Context TaskContext

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(TaskEntityMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
        
    }
}