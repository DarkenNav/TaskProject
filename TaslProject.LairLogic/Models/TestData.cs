using TaskProject.LairLogic.Models.Users;

namespace TaskProject.LairLogic.Models
{
    public static class TestData
    {
        private static List<UserDTO> _users;
        public static List<UserDTO> Users
        { 
            get
            {
                if (_users == null)
                {
                    _users = new List<UserDTO>();
                    for (int i = 0; i < 10; i++)
                    {
                        _users.Add(new UserDTO() { Id = i, Name = $"User {i}" });
                    }
                }
                return _users;
            }
        }

    }
}
