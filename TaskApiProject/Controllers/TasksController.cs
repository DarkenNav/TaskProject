using Microsoft.AspNetCore.Mvc;
using TaskProject.LairLogic.Models.Tasks;
using TaskProject.LairLogic;
using TaskApiProject.Models.Tasks;

namespace TaskApiProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController : Controller
    {
        private readonly TaskService _taskService;
        private readonly UserService _userService;

        public TasksController(TaskService taskService, UserService userService)
        {
            _taskService = taskService;
            _userService = userService;
        }

        [HttpGet("{id}")]
        public ActionResult<TaskModel> Get(int id)
        {
            var task = _taskService.Get(id);

            var taskModel = new TaskModel(task);

            return Ok(taskModel);
        }

        [HttpPost("")]
        public IActionResult Create(TaskCreateModel task)
        {
            var taskId = _taskService.Create(new TaskCreateDTO()
            {
                Subject = task.Subject,
                Description = task.Description,
                ContractorId = task.ContractorId
            });

            return Ok(taskId);
        }

        [HttpPut("{id}")]
        public IActionResult Edit(TaskUpdateModel task)
        {

            var taskId = _taskService.Update(new TaskUpdateDTO()
            {
                Id = task.Id,
                Subject = task.Subject,
                Description = task.Description,
                ContractorId =  task.ContractorId
            });

            return Ok(taskId);
        }
    }
}
