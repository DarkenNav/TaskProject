using T = TaskProject.DAL.Domain.Tasks;

namespace TaskProject.DAL
{
    public class TaskMockData
    {
        private UserMockData _userMockData;

        private List<T.Task> _tasks;

        public TaskMockData(UserMockData userMockDataService)
        {
            _userMockData = userMockDataService;
            _tasks = new List<T.Task>();

            Random rnd = new Random();
            var usersCount = _userMockData.Users.Count;

            for (int i = 1; i < 55; i++)
            {
                int contractorId = rnd.Next(1, usersCount);
                _tasks.Add(new T.Task()
                {
                    Id = i,
                    Subject = $"Task {i}",
                    ContractorId = contractorId,
                    Description = $"Description of task {i}. Created {DateTime.Now.ToString()}"
                }); ;
            }

        }

        public List<T.Task> Tasks => _tasks;

    }
}
