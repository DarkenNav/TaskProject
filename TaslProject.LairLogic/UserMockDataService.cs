using TaskProject.LairLogic.Models.Users;

namespace TaskProject.LairLogic
{
    public class UserMockDataService
    {
        private List<UserDTO> _users;

        public UserMockDataService()
        {
            _users = new List<UserDTO>();
            for (int i = 0; i < 10; i++)
            {
                _users.Add(new UserDTO() { Id = i, Name = $"User {i}" });
            }

        }

        public List<UserDTO> Users => _users;

    }
}
