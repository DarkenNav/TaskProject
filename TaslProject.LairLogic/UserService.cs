using TaskProject.LairLogic.Models;
using TaskProject.LairLogic.Models.Users;

namespace TaskProject.LairLogic
{
    public class UserService
    {
        public UserService() { }

        public List<UserDTO> GetTestUsersList() 
        { 
            return TestData.Users;
        }
    }
}
