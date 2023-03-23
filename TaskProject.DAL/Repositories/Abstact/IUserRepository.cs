﻿using TaskProject.DAL.Domain.Users;

namespace TaskProject.DAL.Repositories.Abstact
{
    public interface IUserRepository : IRepository<User>
    {
        ICollection<User> Get(string search, int skip, int take);
    }
}
