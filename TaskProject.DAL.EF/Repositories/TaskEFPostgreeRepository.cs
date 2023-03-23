﻿using TaskProject.Domain.Repositories.Abstact;
using T = TaskProject.Domain.Models.Tasks;

namespace TaskProject.DAL.EF.Repositories
{
    public class TaskEFPostgreeRepository : ITaskRepository, IRepository<T.Task>
    {

        private readonly PostgreeContext _context;

        public TaskEFPostgreeRepository(PostgreeContext context)
        {
            _context = context;
        }

        public int Count()
        {
            return _context.Tasks.Count();
        }

        public T.Task Create(T.Task item)
        {
            _context.Tasks.Add(item);
            _context.SaveChanges();
            return item;
        }

        public void Delete(int id)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.Id == id);

            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
        }

        public ICollection<T.Task> Get(string search, int skip, int take)
        {
            var tasks = _context.Tasks
                .Where(x => string.IsNullOrEmpty(search) || x.Subject.Contains(search) || x.Description.Contains(search))
                .Skip(skip)
                .Take(take)
                .ToList();

            return tasks;
        }

        public T.Task? Get(int id)
        {
            return _context.Tasks.FirstOrDefault(x => x.Id == id);
        }

        public void Update(T.Task item)
        {
            _context.Tasks.Update(item);
            _context.SaveChanges();
        }
    }
}
