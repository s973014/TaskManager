using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;


namespace Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly AppDbContext _context;

        public ProjectRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Project project)
        {
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Project project)
        {
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            return await _context.Projects
                                 .Include(p => p.Tasks)
                                 .ToListAsync();
        }

        public async Task<Project?> GetByIdAsync(Guid id)
        {
            return await _context.Projects
                                 .Include(p => p.Tasks)
                                 .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task UpdateAsync(Project project)
        {
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
        }
    }
}
