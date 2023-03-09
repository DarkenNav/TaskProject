using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProject.LairLogic.Models.Users;

namespace TaskProject.LairLogic.Models.Tasks
{
    public class TaskUpdateDTO
    {

        public int Id { get; set; }
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
