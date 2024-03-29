﻿using TaskProject.DAL.Domain.Users;
using TaskProject.DAL.Repositories;
using TaskProject.DAL.Repositories.Abstact;
using TaskProject.LairLogic.Models.Users;

namespace TaskProject.LairLogic
{
    public class UserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        public int GetAllCount()
        {
            return _userRepository.Count();
        }


        public List<UserDTO> GetTestUsersList() 
        { 
            var users = _userRepository.Get("", 0, 20);
            var list = users.Select(x => new UserDTO()
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            return list;
        }

        public UserDTO Get(int id)
        {
            var user = _userRepository.Get(id);
            return new UserDTO() { 
                Id = user.Id,
                Name = user.Name
            };
        }

        public UserDTO GetUserFirstOrDefault()
        {
            var user = _userRepository.Get("", 0, 1).FirstOrDefault();
            return new UserDTO()
            {
                Id = user.Id,
                Name = user.Name
            };
        }
    }
}
