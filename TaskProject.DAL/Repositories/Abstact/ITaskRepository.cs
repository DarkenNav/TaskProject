using T = TaskProject.DAL.Domain.Tasks;

namespace TaskProject.DAL.Repositories.Abstact
{
    public interface ITaskRepository: IRepository<T.Task>
    {
    }
}
