using U = TaskProject.Domain.Models.Users;

namespace TaskProject.Domain.Repositories.Abstact
{
    public interface IUserRepository : IRepository<U.User>
    {
        ICollection<U.User> Get(string search, int skip, int take);
    }
}
