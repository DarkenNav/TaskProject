using Microsoft.EntityFrameworkCore;
using TaskProject.Domain.Models.Users;
using T = TaskProject.Domain.Models.Tasks;

namespace TaskProject.DAL.EF
{
    public class PostgreeContext : DbContext
    {
        public PostgreeContext(DbContextOptions<PostgreeContext> options)
            : base(options)
        {
        }


        public DbSet<User> Users => Set<User>();
        public DbSet<T.Task> Tasks => Set<T.Task>();
    }
}