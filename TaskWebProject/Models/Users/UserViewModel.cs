using TaskProject.LairLogic.Models.Users;

namespace TaskWebProject.Models.Users
{

    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public UserViewModel() { }

        public UserViewModel(UserDTO user) 
        { 
            Id = user.Id;
            Name = user.Name;
        }

    }
}
