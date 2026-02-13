using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Services
{
    public interface ITaskService
    {
        Task<TaskItem?> GetTaskAsync(Guid id);
        Task<IEnumerable<TaskItem>> GetAllTasksAsync();
        Task<IEnumerable<TaskItem>> GetTasksByProjectIdAsync(Guid projectId);
        Task CreateTaskAsync(TaskItem task);
        Task UpdateTaskAsync(TaskItem task);
        Task DeleteTaskAsync(Guid id);
    }
}
