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
        private readonly UserListService _userListService;

        public TasksController(TaskService taskService, UserService userService, UserListService userListService)
        {
            _taskService = taskService;
            _userService = userService;
            _userListService = userListService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create() 
        {
            var userlist = _userListService.Get(0, 5);
            var model = new TaskNewViewModel(userlist.Users);

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
