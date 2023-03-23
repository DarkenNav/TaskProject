using Microsoft.AspNetCore.Mvc;
using TaskProject.LairLogic;
using TaskProject.LairLogic.Models.Tasks;
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
            var users = _userService.GetTestUsersList();
            var model = new TaskNewViewModel(users);

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(TaskCreateViewModel task)
        {
            var taskId = _taskService.Create(new TaskCreateDTO() 
            { 
                Subject = task.Subject,
                Description = task.Description,
                ContractorId = task.ContractorId
            });

            return RedirectToAction("Edit", new { id = taskId });
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
                return View("NotFound");

            var task = _taskService.Get(id.Value);
            if (task == null)
                return NotFound(id);

            var users = _userService.GetTestUsersList();

            var taskModel = new TaskViewModel(task, users);


            return View(taskModel);
        }

        [HttpPost]
        public IActionResult Edit(TaskUpdateViewModel task)
        {

            var taskId = _taskService.Update(new TaskUpdateDTO()
            {
                Id = task.Id,
                Subject = task.Subject,
                Description = task.Description,
                ContractorId = task.ContractorId
            });

            return RedirectToAction("Edit", new { id = taskId });
        }

    }
}
