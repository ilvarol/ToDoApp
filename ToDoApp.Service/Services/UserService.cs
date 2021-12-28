using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.Core.Extensions;
using ToDoApp.Core.Models;
using ToDoApp.Core.Repositories;
using ToDoApp.Core.Services;

namespace ToDoApp.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task CreateUser(User user)
        {
            user.Id = Guid.NewGuid().ToString();
            user.Password = user.Password.ToMd5Hash();

            await _userRepository.CreateAsync(user.Id, user);
        }

        public async Task<User> GetUserByName(string username)
        {
            return await _userRepository.GetOne(x => x.Username == username);
        }

        public bool CheckPassword(User user, string password)
        {
            return user.Password == password.ToMd5Hash();
        }
    }
}