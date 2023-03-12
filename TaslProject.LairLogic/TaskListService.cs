using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using TaskProject.LairLogic.Models;
using TaskProject.LairLogic.Models.Tasks;

namespace TaskProject.LairLogic
{
    public class TaskListService
    {
        private UserService _userService;
        private TaskMockDataService _taskMockDataService;
        public TaskListService(UserService userService, TaskMockDataService taskMockDataService) 
        {
            _userService = userService;
            _taskMockDataService = taskMockDataService;
        }

        public TaskListDTO Get(int skip, int take)
        {
            var result = new TaskListDTO();
            result.Skip = skip;
            result.Take = take;

            var count = _taskMockDataService.Tasks.Count;
            result.TotalCount = count;

            if(skip > count)
            {
                result.Tasks = new List<TaskDTO>();
                return result;
            }

            result.Tasks = _taskMockDataService.Tasks.Skip(skip).Take(take).ToList();

            return result;
        }
   


    }
}
