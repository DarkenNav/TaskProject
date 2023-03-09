using TaskProject.LairLogic.Models.Users;
using TaskWebProject.Models.Users;

namespace TaskWebProject.Models.Tasks
{
    public class TaskNewViewModel
    {

        /// <summary>
        /// Исполнитель задачи
        /// </summary>
        public List<UserViewModel> Contractors { get; set; }


        public TaskNewViewModel(List<UserDTO> contractors)
        {
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
