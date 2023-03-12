using TaskProject.DAL.Domain.Users;
using TaskProject.DAL.Repositories;
using TaskProject.DAL.Repositories.Abstact;
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

            var count = _taskRepository.GetCount(x => true);
            result.TotalCount = count;

            if(skip > count)
            {
                result.Tasks = new List<TaskDTO>();
                return result;
            }

            result.Tasks = _taskRepository
                .Get(x => true, skip, take)
                .Select(x => new TaskDTO() {
                    Id = x.Id,
                    Subject = x.Subject,
                    Contractor = UserDTO.Create(_userRepository.Get(x.ContractorId)),   
                    Description = x.Description
                }).ToList();

            return result;
        }
   


    }
}
