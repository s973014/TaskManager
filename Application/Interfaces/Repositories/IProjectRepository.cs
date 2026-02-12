using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Repositories
{
    public interface IProjectRepository
    {
        Task<Project?> GetByIdAsync(Guid id);
        Task<IEnumerable<Project>> GetAllAsync();
        Task AddAsync(Project project);
        Task UpdateAsync(Project project);
        Task DeleteAsync(Project project);
    }
}
