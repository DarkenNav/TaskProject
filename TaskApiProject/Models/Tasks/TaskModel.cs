using Microsoft.AspNetCore.Mvc;
using TaskApiProject.Models.Users;
using TaskProject.LairLogic.Models.Tasks;
using TaskProject.LairLogic.Models.Users;

namespace TaskApiProject.Models.Tasks
{
    public class TaskModel
    {
        /// <summary>
        /// Идентификатор задачи
        /// </summary>
        [FromRoute(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Заголовок
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Исполнитель задачи для визуализации
        /// </summary>
        public UserModel Contractor { get; set; }

        /// <summary>
        /// Описание задачи
        /// </summary>
        public string Description { get; set; }


        public TaskModel() { }

        public TaskModel(TaskDTO task)
        {
            Id = task.Id;
            Subject = task.Subject;
            if (task.Contractor != null)
            {
                Contractor = new UserModel(task.Contractor);
            }
            Description = task.Description;

        }

    }
}
