using Microsoft.AspNetCore.Mvc;
using TaskApiProject.Models.Tasks;
using TaskProject.LairLogic;

namespace TaskApiProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskListController : ControllerBase
    {
        private readonly TaskListService _taskListService;

        public TaskListController(TaskListService taskListService)
        {
            _taskListService = taskListService;
        }

        [HttpGet("Filter")]
        public ActionResult<TaskListModel> Filter([FromQuery] int skip, [FromQuery] int take)
        {
            if (take < 0)
                take = 10;

            var taskList = _taskListService.Get(skip, take);

            var model = new TaskListModel(taskList, skip, take);

            return Ok(model);
        }
    }
}