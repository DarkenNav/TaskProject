using Microsoft.AspNetCore.Mvc;
using TaskProject.LairLogic;
using TaskWebProject.Models.Tasks;

namespace TaskWebProject.Controllers
{
    public class TasksController : Controller
    {
        private readonly TaskService _taskService;
        private readonly UserService _userService;

        public TasksController(TaskService taskService, UserService userService)
        {
            _taskService = taskService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create() 
        {
            var model = new TaskNewViewModel(_userService.GetTestUsersList());

            return View(model);
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
