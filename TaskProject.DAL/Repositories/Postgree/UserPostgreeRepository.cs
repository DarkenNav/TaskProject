using Dapper;
using Npgsql;
using TaskProject.DAL.Domain.Users;
using TaskProject.DAL.Repositories.Abstact;

namespace TaskProject.DAL.Repositories.Mock
{
    public class UserPostgreeRepository : IUserRepository, IRepository<User>
    {

        private readonly NpgsqlConnection _connection;

        public UserPostgreeRepository(string connectionString)
        {
            _connection = new NpgsqlConnection(connectionString);
        }

        public User Create(User item)
        {
            item.CreatedDate = DateTime.UtcNow;

            var query = $"INSERT INTO public.\"Users\"(\"Name\", \"Surname\", \"Phone\", \"Email\", \"CreatedDate\") " +
                $"VALUES ('{item.Name}', '{item.Surname}', '{item.Phone}', '{item.Email}', '{item.CreatedDate}'); " +
                $"SELECT CAST(SCOPE_IDENTITY() as int)\"";

            item.Id = _connection.ExecuteScalar<int>(query);           

            return item;
        }

        public void Delete(int id)
        {
            _connection.Execute("DELETE public.\"Users\" WHERE Id = @Id", new { Id = id });
        }

        public User Get(int id)
        {
            var user = _connection.Query<User>($"SELECT * FROM public.\"Users\" WHERE \"Id\" = {id}").FirstOrDefault();
            return user;
        }

        public ICollection<User> Get(string search, int skip, int take)
        {
            var searchQuery = string.IsNullOrWhiteSpace(search) ? "" : $"WHERE \"Name\" ilike 'search%' or \"Surname\" ilike 'search%'";

            var users = _connection.Query<User>($"SELECT * FROM public.\"Users\" {searchQuery} OFFSET {skip} LIMIT {take}").ToList();
            return users ?? new List<User>();
        }

        public int Count()
        {
            var count = _connection.ExecuteScalar<int>($"SELECT count(*) FROM public.\"Users\"");
            return count;
        }

        public void Update(User item)
        {
            throw new NotImplementedException();
        }
    }
}
