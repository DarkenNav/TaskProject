using Microsoft.AspNetCore.Mvc;
using TaskApiProject.Models.Users;

namespace TaskApiProject.Models.Tasks
{
    public class TaskUpdateModel
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
        public int ContractorId { get; set; }

        /// <summary>
        /// Описание задачи
        /// </summary>
        public string Description { get; set; }

    }
}
