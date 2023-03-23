using TaskProject.Domain.Repositories.Abstact;
using TaskProject.LairLogic.Models.Tasks;
using TaskProject.LairLogic.Models.Users;

namespace TaskProject.LairLogic
{
    public class TaskListService
    {
        private IUserRepository _userRepository;
        private ITaskRepository _taskRepository;
        public TaskListService(IUserRepository userRepository, ITaskRepository taskRepository) 
        {
            _userRepository = userRepository;
            _taskRepository = taskRepository;
        }

        public TaskListDTO Get(int skip, int take)
        {
            var result = new TaskListDTO
            {
                Skip = skip,
                Take = take
            };

            var count = _taskRepository.Count();
            result.TotalCount = count;

            if (skip > count)
            {
                result.Tasks = new List<TaskDTO>();
                return result;
            }

            result.Tasks = _taskRepository
                .Get(string.Empty, skip, take)
                .Select(x => new TaskDTO()
                {
                    Id = x.Id,
                    Subject = x.Subject,
                    Contractor = x.ContractorId == null ? null : UserDTO.Create(_userRepository.Get(x.ContractorId.Value)),
                    Description = x.Description
                }).ToList();
            return result;
        }
   


    }
}
