using System.Collections.Generic;
using TaskProject.Logic2.Models.Users;

namespace TaskProject.Logic2
{
    public class UserService
    {
        public UserService() { }

        public List<UserDTO> GetTestUsersList() 
        { 
            var users = new List<UserDTO>();
            for (int i = 0; i < 10; i++)
            {
                users.Add(new UserDTO() { Id = i, Name = $"User {i.ToString()}" });
            }
            return users;
        }
    }
}
