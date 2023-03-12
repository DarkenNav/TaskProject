using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaskWebProject.Models;

namespace TaskWebProject.Controllers
{
    public class TaskListController : Controller
    {
        private readonly ILogger<TaskListController> _logger;

        public TaskListController(ILogger<TaskListController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}