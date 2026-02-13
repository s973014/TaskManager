using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;

        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateTaskAsync(TaskItem task)
        {
            await _repository.AddAsync(task);
        }

        public async Task DeleteTaskAsync(Guid id)
        {
            var task = await _repository.GetByIdAsync(id);
            if (task != null)
                await _repository.DeleteAsync(task);
        }

        public async Task<IEnumerable<TaskItem>> GetAllTasksAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TaskItem?> GetTaskAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<TaskItem>> GetTasksByProjectIdAsync(Guid projectId)
        {
            return await _repository.GetByProjectIdAsync(projectId);
        }

        public async Task UpdateTaskAsync(TaskItem task)
        {
            await _repository.UpdateAsync(task);
        }
    }
}
