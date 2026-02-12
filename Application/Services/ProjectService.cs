using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _repository;

        public ProjectService(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateProjectAsync(Project project)
        {
            await _repository.AddAsync(project);
        }

        public async Task DeleteProjectAsync(Guid id)
        {
            var project = await _repository.GetByIdAsync(id);
            if (project != null)
                await _repository.DeleteAsync(project);
        }

        public async Task<IEnumerable<Project>> GetAllProjectsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Project?> GetProjectAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task UpdateProjectAsync(Project project)
        {
            await _repository.UpdateAsync(project);
        }
    }
}
