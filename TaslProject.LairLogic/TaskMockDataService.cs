using System;
using System.Data;
using TaskProject.LairLogic.Models.Tasks;
using TaskProject.LairLogic.Models.Users;

namespace TaskProject.LairLogic
{
    public class TaskMockDataService
    {
        private UserMockDataService _userMockDataService;

        private List<TaskDTO> _tasks;

        public TaskMockDataService(UserMockDataService userMockDataService)
        {
            _userMockDataService = userMockDataService;
            _tasks = new List<TaskDTO>();

            Random rnd = new Random();
            var usersCount = _userMockDataService.Users.Count;

            for (int i = 0; i < 50; i++)
            {
                int contractorId = rnd.Next(0, usersCount);
                var contractor = _userMockDataService.Users.FirstOrDefault(x => x.Id == contractorId);
                _tasks.Add(new TaskDTO()
                {
                    Id = i,
                    Subject = $"Task {i}",
                    Contractor = contractor,
                    Description = $"Description of task {i}. Created {DateTime.Now.ToString()}"
                }); ;
            }

        }

        public List<TaskDTO> Tasks => _tasks;

    }
}
