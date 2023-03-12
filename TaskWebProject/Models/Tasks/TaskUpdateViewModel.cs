using Microsoft.AspNetCore.Mvc;

namespace TaskWebProject.Models.Tasks
{
    public class TaskUpdateViewModel
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
        /// Исполнитель задачи для мапинга формы
        /// </summary>
        public int ContractorId { get; set; }

        /// <summary>
        /// Описание задачи
        /// </summary>
        public string Description { get; set; }

    }
}
