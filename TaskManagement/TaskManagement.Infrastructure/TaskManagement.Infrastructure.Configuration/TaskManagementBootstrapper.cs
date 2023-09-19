using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _0_Framework.Domain;
using _0_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Application;
using TaskManagement.Application.Contract.Task;
using TaskManagement.Domain.TaskAgg.Repository;
using TaskManagement.Infrastructure.EfCore;
using TaskManagement.Infrastructure.EfCore.Repositories;

namespace TaskManagement.Infrastructure.Configuration
{
    public class TaskManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            
            services.AddTransient< ITaskApplication , TaskApplication >();

            // services.AddDbContext<TaskContext>(x => x.UseSqlServer(connectionString));
            services.AddDbContextPool<TaskContext>(o=>o.UseSqlServer(connectionString));
            services.AddTransient<ITaskRepository, TaskRepository>();
        }
    }
}