using Application.Interfaces.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Project project)
        {
            if (!ModelState.IsValid)
                return View(project);

            await _projectService.CreateProjectAsync(project);
            return RedirectToAction("Index","Home");
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var project = await _projectService.GetProjectAsync(id);
            if (project == null)
                return NotFound();

            return View(project);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var project = await _projectService.GetProjectAsync(id);
            if (project == null)
                return NotFound();

            return View(project);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, Project project)
        {
            if (!ModelState.IsValid)
                return View(project);

            var existingProject = await _projectService.GetProjectAsync(id);
            if (existingProject == null)
                return NotFound();

            // Обновляем только нужные поля
            existingProject.Name = project.Name;
            existingProject.Description = project.Description;

            await _projectService.UpdateProjectAsync(existingProject);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var project = await _projectService.GetProjectAsync(id);
            if (project == null)
                return NotFound();

            return View(project);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _projectService.DeleteProjectAsync(id);
            return RedirectToAction("Index", "Home");
        }

    }
}
