using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using TaskProject.LairLogic.Models.Tasks;
using TaskProject.LairLogic.Models.Users;
using TaskWebProject.Models.Users;

namespace TaskWebProject.Models.Tasks
{
    public class TaskViewModel
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
        public UserViewModel Contractor { get; set; }


        /// <summary>
        /// Исполнитель задачи для мапинга формы
        /// </summary>
        public int ContractorId { get; set; }

        /// <summary>
        /// Возможные исполнители задачи
        /// </summary>
        public List<UserViewModel> Contractors { get; set; }

        /// <summary>
        /// Описание задачи
        /// </summary>
        public string Description { get; set; }


        public TaskViewModel() { }

        public TaskViewModel(TaskDTO task, List<UserDTO> contractors)
        {
            Id = task.Id;
            Subject = task.Subject;
            if (task.Contractor != null)
            {
                Contractor = new UserViewModel(task.Contractor);
                ContractorId = Contractor.Id;
            }
            Description = task.Description;

            Contractors = new List<UserViewModel>();
            foreach (var contractor in contractors)
            {
                Contractors.Add(new UserViewModel()
                {
                    Id = contractor.Id,
                    Name = contractor.Name
                });
            }
        }

    }
}
