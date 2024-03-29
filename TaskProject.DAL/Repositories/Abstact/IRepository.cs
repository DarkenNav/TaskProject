﻿using System.Linq.Expressions;

namespace TaskProject.DAL.Repositories.Abstact
{
    public interface IRepository<T>
    {
        public T Get(int id);
        //public ICollection<T> Get(Func<T, bool> where);
        //public int GetCount(Func<T, bool> where);

        //public ICollection<T> Get(Func<T, bool> where, int skip, int take);

        public T Create(T item);
        public void Update(T item);

        public void Delete(int id);
        int Count();

    }
}
