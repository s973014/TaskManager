using Application.Interfaces.Services;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly ITaskService _taskService;

        public ProjectsController(IProjectService projectService, ITaskService taskService)
        {
            _projectService = projectService;
            _taskService = taskService;
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


            ViewBag.NewTask = new TaskItem { ProjectId = id };
            return View(project);
        }

        [HttpPost]
        public async Task<IActionResult> EditProject(Guid id, Project project)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Edit", new { id });

            var existingProject = await _projectService.GetProjectAsync(id);
            if (existingProject == null)
                return NotFound();

            existingProject.Name = project.Name;
            existingProject.Description = project.Description;

            await _projectService.UpdateProjectAsync(existingProject);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> AddTask(TaskItem task)
        {
            if (task.DueDate.HasValue)
                task.DueDate = DateTime.SpecifyKind(task.DueDate.Value, DateTimeKind.Utc);


            if (task.ProjectId == Guid.Empty)
                return BadRequest("ProjectId не указан");

            await _taskService.CreateTaskAsync(task);

            return RedirectToAction("Edit", new { id = task.ProjectId });
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
