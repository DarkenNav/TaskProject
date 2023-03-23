using TaskProject.Domain.Models.Users;

namespace TaskProject.LairLogic.Models.Users
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static UserDTO Create(User user)
        {
            if (user == null)
                return null;
            
            return new UserDTO()
            {
                Id = user.Id,
                Name = user.Name
            };
        }
    }
}
