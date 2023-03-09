using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Xml.Linq;
using TaskWebProject.Models.Tasks;

namespace TaskWebProject.Controllers
{
    public class TasksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create() 
        { 
        
            return View();
        }

        [HttpPost]
        public IActionResult Create(TaskCreateViewModel task)
        {
            var taskId = 1;

            return RedirectToAction("Edit", new { taskId });
        }

        [HttpGet]
        public IActionResult Edit(int taskId)
        {
            var task = new TaskViewModel() { 
                Id = taskId, 
                Contractor = 2, 
                Description = "Good day", 
                Subject="Hello"
            };

            return View(task);
        }

        [HttpPost]
        public IActionResult Edit(TaskViewModel task)
        {

            return View(task);
        }

    }
}
