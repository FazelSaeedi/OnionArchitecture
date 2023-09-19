using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Domain.TaskAgg.Entities;

namespace TaskManagement.Infrastructure.EfCore.Mappings
{
    public class TaskEntityMapping : IEntityTypeConfiguration<TaskEntity>
    {

        public void Configure(EntityTypeBuilder<TaskEntity> builder)
        {
            

            builder.ToTable("Tasks");
            builder.HasKey(x => x.Id);


            builder.OwnsOne(t => t.DueDate, d =>
            {
                d.Property(dd => dd.Value).HasColumnName("DueDate");
            });
            

        }


    }
}