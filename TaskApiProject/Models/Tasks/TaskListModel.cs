using TaskProject.LairLogic.Models.Tasks;

namespace TaskApiProject.Models.Tasks
{
    public class TaskListModel
    {
        public List<TaskShortModel> Tasks { get; set; }

        public int TotalCount { get; set; }
        public int Skiped { get; set; }
        public int Taken { get; set; }

        public TaskListModel()
        {
            Tasks = new List<TaskShortModel>();
        }

        public TaskListModel(TaskListDTO list, int page, int size)
        {
            Tasks = new List<TaskShortModel>();
            foreach (TaskDTO task in list.Tasks)
            {
                Tasks.Add(new TaskShortModel(task));
            }

            TotalCount = list.TotalCount;
            Skiped = page;
            Taken = size;

        }

    }
}
