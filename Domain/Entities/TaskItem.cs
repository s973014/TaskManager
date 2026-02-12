using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Enums;

namespace Domain.Entities
{
    public class TaskItem : BaseEntity
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }

        public Enums.TaskStatus Status { get; set; } = Enums.TaskStatus.ToDo;
        public TaskPriority Priority { get; set; } = TaskPriority.Medium;
        public DateTime? DueDate { get; set; }
        public Guid ProjectId { get; set; }
        public Project Project { get; set; } = null!;

    }
}
