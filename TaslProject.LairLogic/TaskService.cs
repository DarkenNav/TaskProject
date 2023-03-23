using System.Diagnostics.Contracts;
using TaskProject.Domain.Repositories.Abstact;
using TaskProject.LairLogic.Models.Tasks;
using TaskProject.LairLogic.Models.Users;
using T = TaskProject.Domain.Models.Tasks;

namespace TaskProject.LairLogic
{
    public class TaskService
    {
        private IUserRepository _userRepository;
        private ITaskRepository _taskRepository;
        public TaskService(IUserRepository userRepository, ITaskRepository taskRepository) 
        {
            _userRepository = userRepository;
            _taskRepository = taskRepository;
        }

        public TaskDTO Get(int id)
        {
            var task = _taskRepository.Get(id);
            UserDTO contractor = null;
            if (task.ContractorId != null && task.ContractorId != 0)
            {
                var _contractor = _userRepository.Get(task.ContractorId.Value);
                contractor = new UserDTO()
                {
                    Id = _contractor.Id,
                    Name = _contractor.Name
                };
            }
            return new TaskDTO() { 
                Id = task.Id,
                Subject = task.Subject,
                Contractor = contractor,
                Description = task.Description
            };
        }

        public int Create(TaskCreateDTO taskCreate)
        {
            var newTask = new T.Task()
            {
                ContractorId = taskCreate.ContractorId,
                Description = taskCreate.Description,
                Subject = taskCreate.Subject
            };

            var task = _taskRepository.Create(newTask); 

            return task.Id;
        }

        public object Update(TaskUpdateDTO taskUpdate)
        {
            var newTask = new T.Task()
            {
                Id = taskUpdate.Id,
                ContractorId = taskUpdate.ContractorId,
                Description = taskUpdate.Description,
                Subject = taskUpdate.Subject
            };

             _taskRepository.Update(newTask);

            return taskUpdate.Id;

        }     


    }
}
