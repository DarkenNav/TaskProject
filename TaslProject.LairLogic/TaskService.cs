using TaskProject.DAL.Repositories;
using TaskProject.DAL.Repositories.Abstact;
using TaskProject.LairLogic.Models.Tasks;
using TaskProject.LairLogic.Models.Users;
using T = TaskProject.DAL.Domain.Tasks;

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
            var contractor = _userRepository.Get(task.ContractorId);
            return new TaskDTO() { 
                Id = task.Id,
                Subject = task.Subject,
                Contractor = new UserDTO()
                {
                    Id = contractor.Id,
                    Name = contractor.Name
                },
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
