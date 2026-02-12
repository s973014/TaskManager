using Domain.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Project : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    }
}
