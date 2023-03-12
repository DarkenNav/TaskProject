using TaskProject.LairLogic.Models.Users;

namespace TaskApiProject.Models.Users
{

    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public UserModel() { }

        public UserModel(UserDTO user) 
        { 
            Id = user.Id;
            Name = user.Name;
        }

    }
}
