using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.Core.Models;

namespace ToDoApp.Core.Services
{
    public interface IToDoListService
    {
        Task<List<ToDoList>> GetToDoLists();
        Task<ToDoList> GetToDoListById(string id);
        Task CreateToDoList(ToDoList toDoList);
        Task UpdateToDoList(ToDoList toDoList);
        Task DeleteToDoList(string id);        
    }
}