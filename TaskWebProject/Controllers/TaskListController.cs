using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaskProject.LairLogic;
using TaskWebProject.Models;
using TaskWebProject.Models.Tasks;

namespace TaskWebProject.Controllers
{
    public class TaskListController : Controller
    {
        private readonly TaskListService _taskListService;
        private readonly UserService _userService;
        public TaskListController(TaskListService taskListService, 
            UserService userService)
        {
            _taskListService = taskListService;
            _userService = userService;
        }

        public IActionResult Index([FromQuery(Name = "page")] int page, [FromQuery(Name = "page-size")] int size)
        {
            if (size == 0)
                size = 10;

            var skip = page * size;

            var usersCount = _userService.GetAllCount();
            var user = _userService.Get(1);

            var taskList = _taskListService.Get(skip, size);

            var model = new TaskListViewModel(taskList, page, size);

            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}