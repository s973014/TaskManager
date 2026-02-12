using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Configurations
{
    public class TaskItemConfiguration : IEntityTypeConfiguration<TaskItem>
    {
        public void Configure(EntityTypeBuilder<TaskItem> builder)
        {
            builder.ToTable("tasks");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                   .HasColumnName("id");

            builder.Property(t => t.Title)
                   .HasColumnName("title")
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(t => t.Description)
                   .HasColumnName("description")
                   .HasMaxLength(2000);

            builder.Property(t => t.Status)
                   .HasColumnName("status")
                   .IsRequired();

            builder.Property(t => t.Priority)
                   .HasColumnName("priority")
                   .IsRequired();

            builder.Property(t => t.DueDate)
                   .HasColumnName("due_date");

            builder.Property(t => t.ProjectId)
                   .HasColumnName("project_id")
                   .IsRequired();

            builder.Property(t => t.CreatedAt)
                   .HasColumnName("created_at")
                   .IsRequired();

            builder.Property(t => t.UpdatedAt)
                   .HasColumnName("updated_at");

            builder.HasIndex(t => t.ProjectId);
            builder.HasIndex(t => t.Status);
        }
    }
}
