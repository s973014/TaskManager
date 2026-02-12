using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Services
{
    public interface IProjectService
    {
        Task<Project?> GetProjectAsync(Guid id);
        Task<IEnumerable<Project>> GetAllProjectsAsync();
        Task CreateProjectAsync(Project project);
        Task UpdateProjectAsync(Project project);
        Task DeleteProjectAsync(Guid id);
    }
}
