using System.Threading.Tasks;
using TaskProject.LairLogic.Models;
using TaskProject.LairLogic.Models.Tasks;

namespace TaskProject.LairLogic
{
    public class TaskService
    {
        public TaskService() { }

        public TaskDTO Get(int id)
        {
            var task = new TaskDTO()
            {
                Id = id,
                Contractor = TestData.Users.FirstOrDefault(),
                Description = "Good day",
                Subject = "Hello"
            };

            return task;
        }

        public int Create(TaskCreateDTO task)
        {
            var contractor = TestData.Users.FirstOrDefault(x => x.Id == task.ContractorId);

            var newTask = new TaskDTO()
            {
                Id = 100,
                Contractor = contractor,
                Description = task.Description,
                Subject = task.Subject
            };

            return newTask.Id;
        }

        public object Update(TaskUpdateDTO task)
        {

            return task.Id;
        }     


    }
}
