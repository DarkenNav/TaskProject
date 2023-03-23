using TaskProject.Domain.Repositories.Abstact;
using TaskProject.LairLogic.Models.Users;

namespace TaskProject.LairLogic
{
    public class UserListService
    {
        private readonly IUserRepository _userRepository;
        public UserListService(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        public UserListDTTO Get(int skip, int take)
        {
            var result = new UserListDTTO
            {
                Skip = skip,
                Take = take
            };

            var count = _userRepository.Count();
            result.TotalCount = count;

            if (skip > count)
            {
                result.Users = new List<UserDTO>();
                return result;
            }

            result.Users = _userRepository
                .Get(string.Empty, skip, take)
                .Select(x => new UserDTO()
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();
            return result;
        }
   


    }
}
