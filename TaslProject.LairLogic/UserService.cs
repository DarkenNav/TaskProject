using TaskProject.LairLogic.Models.Users;

namespace TaskProject.LairLogic
{
    public class UserService
    {
        private UserMockDataService _testUserDataService;

        public UserService(UserMockDataService testUserDataService) 
        {
            _testUserDataService = testUserDataService;
        }

        public List<UserDTO> GetTestUsersList() 
        { 
            return _testUserDataService.Users;
        }

        public UserDTO GetUser(int id)
        {
            return _testUserDataService.Users.FirstOrDefault(x => x.Id == id); 
        }

        public UserDTO GetUserFirstOrDefault()
        {
            return _testUserDataService.Users.FirstOrDefault();
        }
    }
}
