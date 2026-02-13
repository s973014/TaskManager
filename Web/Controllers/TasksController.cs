using Application.Interfaces.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class TasksController : Controller
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public IActionResult Create(Guid projectId)
        {
            var task = new TaskItem { ProjectId = projectId };
            return View(task);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskItem task)
        {
            if (!ModelState.IsValid)
                return View(task);

            await _taskService.CreateTaskAsync(task);
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var task = await _taskService.GetTaskAsync(id);
            if (task == null)
                return NotFound();

            return View(task);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, TaskItem task)
        {
            if (task.DueDate.HasValue)
                task.DueDate = DateTime.SpecifyKind(task.DueDate.Value, DateTimeKind.Utc);

            var existingTask = await _taskService.GetTaskAsync(id);
            if (existingTask == null)
                return NotFound();

            existingTask.Title = task.Title;
            existingTask.Description = task.Description;
            existingTask.Status = task.Status;
            existingTask.Priority = task.Priority;
            existingTask.DueDate = task.DueDate;

            await _taskService.UpdateTaskAsync(existingTask);
            return RedirectToAction(
                "Edit",
                "Projects",
                new { id = existingTask.ProjectId }
            );
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var task = await _taskService.GetTaskAsync(id);
            if (task == null)
                return NotFound();

            return View(task);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var task = await _taskService.GetTaskAsync(id);
            if (task == null)
                return NotFound();

            var projectId = task.ProjectId;

            await _taskService.DeleteTaskAsync(id);

            
            return RedirectToAction(
                "Edit",
                "Projects",
                new { id = projectId }
            );
        }



        public async Task<IActionResult> Details(Guid id)
        {
            var task = await _taskService.GetTaskAsync(id);
            if (task == null)
                return NotFound();

            return View(task);
        }
    }
}
