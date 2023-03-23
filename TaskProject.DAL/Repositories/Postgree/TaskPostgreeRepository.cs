using Dapper;
using Npgsql;
using TaskProject.Domain.Repositories.Abstact;
using T = TaskProject.Domain.Models.Tasks;

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

        public ICollection<T.Task> Get(string search, int skip, int take)
        {
            var searchQuery = string.IsNullOrWhiteSpace(search) ? "" : $"WHERE \"Subject\" ilike '%search%' or \"Description\" ilike '%search%'";

            var tasks = _connection.Query<T.Task>($"SELECT * FROM public.\"Tasks\" {searchQuery} OFFSET {skip} LIMIT {take}").ToList();
            return tasks ?? new List<T.Task>();
        }

        public int Count()
        {
            var count = _connection.ExecuteScalar<int>($"SELECT count(*) FROM public.\"Tasks\"");
            return count;
        }

        public void Update(T.Task item)
        {
            throw new NotImplementedException();
        }
    }
}
