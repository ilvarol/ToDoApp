using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.Core.Models;

namespace ToDoApp.Core.Services
{
    public interface IUserService
    {
        Task<User> GetUserByName(string name);
        Task CreateUser(User toDoList);
        bool CheckPassword(User user, string password);
    }
}