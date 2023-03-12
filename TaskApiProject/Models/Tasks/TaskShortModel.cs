using Microsoft.AspNetCore.Mvc;
using TaskProject.LairLogic.Models.Tasks;

namespace TaskApiProject.Models.Tasks
{
    public class TaskShortModel
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


        public string ContractorName { get; set; }

        /// <summary>
        /// Описание задачи
        /// </summary>
        public string Description { get; set; }


        public TaskShortModel() { }

        public TaskShortModel(TaskDTO task)
        {
            Id = task.Id;
            Subject = task.Subject;
            if (task.Contractor != null)
            {
                ContractorName = task.Contractor.Name;
            }

            if (!string.IsNullOrEmpty(task.Description))
            {
                Description = task.Description.Length < 47 ? task.Description : $"{task.Description[..47]}..." ;
            }
        }

    }
}
