using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using TaskProject.LairLogic.Models;
using TaskProject.LairLogic.Models.Tasks;

namespace TaskProject.LairLogic
{
    public class TaskService
    {
        private UserService _userService;
        private TaskMockDataService _taskMockDataService;
        public TaskService(UserService userService, TaskMockDataService taskMockDataService) 
        {
            _userService = userService;
            _taskMockDataService = taskMockDataService;
        }

        public TaskDTO Get(int id)
        {
            var task = _taskMockDataService.Tasks.FirstOrDefault(x => x.Id == id);
            return task;
        }

        public int Create(TaskCreateDTO task)
        {
            var contractor = _userService.GetUser(task.ContractorId);

            var newTaskId = _taskMockDataService.Tasks.Count + 1;
            var newTask = new TaskDTO()
            {
                Id = newTaskId,
                Contractor = contractor,
                Description = task.Description,
                Subject = task.Subject
            };

            _taskMockDataService.Tasks.Add(newTask);

            return newTask.Id;
        }

        public object Update(TaskUpdateDTO taskUpdate)
        {
            var task = _taskMockDataService.Tasks.FirstOrDefault(x => x.Id == taskUpdate.Id);

            if (task == null)
                throw new ArgumentException();

            task.Subject = taskUpdate.Subject;
            task.Description = taskUpdate.Description;
            task.Contractor = _userService.GetUser(taskUpdate.ContractorId);

            return task.Id;
        }     


    }
}
