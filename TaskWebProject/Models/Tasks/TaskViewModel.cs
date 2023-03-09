using TaskProject.LairLogic.Models.Tasks;
using TaskWebProject.Models.Users;

namespace TaskWebProject.Models.Tasks
{
    public class TaskViewModel
    {
        /// <summary>
        /// Идентификатор задачи
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Заголовок
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Исполнитель задачи
        /// </summary>
        public UserViewModel Contractor { get; set; }

        /// <summary>
        /// Описание задачи
        /// </summary>
        public string Description { get; set; }


        public TaskViewModel() { }

        public TaskViewModel(TaskDTO task) 
        {
            Id = task.Id;
            Subject = task.Subject;
            if (task.Contractor != null)
            {
                Contractor = new UserViewModel(task.Contractor);
            }
            Description = task.Description;
        }

    }
}
