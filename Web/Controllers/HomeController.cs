using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web.ViewModels;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProjectService _projectService;

        public HomeController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public async Task<IActionResult> Index()
        {
            var recentProjects = await _projectService.GetAllProjectsAsync();
            return View(recentProjects);
        }
    }
}
