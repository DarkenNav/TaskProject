namespace TaskProject.Domain.Repositories.Abstact
{
    public interface IRepository<T>
    {
        public T? Get(int id);

        public T Create(T item);
        public void Update(T item);

        public void Delete(int id);
        int Count();

    }
}
