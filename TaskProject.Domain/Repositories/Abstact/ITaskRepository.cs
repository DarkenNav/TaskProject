using T = TaskProject.Domain.Models.Tasks;

namespace TaskProject.Domain.Repositories.Abstact
{
    public interface ITaskRepository: IRepository<T.Task>
    {
        ICollection<T.Task> Get(string search, int skip, int take);
    }
}
