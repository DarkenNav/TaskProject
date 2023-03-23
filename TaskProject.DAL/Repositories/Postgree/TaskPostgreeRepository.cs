using Npgsql;
using TaskProject.DAL.Domain.Users;
using TaskProject.DAL.Repositories.Abstact;
using T = TaskProject.DAL.Domain.Tasks;

namespace TaskProject.DAL.Repositories.Postgree
{
    public class TaskPostgreeRepository : ITaskRepository, IRepository<T.Task>
    {

        private readonly NpgsqlConnection _connection;

        public TaskPostgreeRepository(string connectionString)
        {
            _connection = new NpgsqlConnection(connectionString);
        }

        public T.Task Create(T.Task item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public T.Task Get(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<T.Task> Get(Func<T.Task, bool> where)
        {
            throw new NotImplementedException();
        }

        public ICollection<T.Task> Get(Func<T.Task, bool> where, int skip, int take)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public void Update(T.Task item)
        {
            throw new NotImplementedException();
        }
    }
}
