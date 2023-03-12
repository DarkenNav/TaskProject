namespace TaskApiProject.Models.Tasks
{
    public class TaskCreateModel
    {
        /// <summary>
        /// Заголовок
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Исполнитель задачи
        /// </summary>
        public int ContractorId { get; set; }

        /// <summary>
        /// Описание задачи
        /// </summary>
        public string Description { get; set; }

    }
}
