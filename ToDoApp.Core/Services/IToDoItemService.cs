using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.Core.Models;

namespace ToDoApp.Core.Services
{
    public interface IToDoItemService
    {
        Task<List<ToDoItem>> GetToDoItemsAsync();
        Task<ToDoItem> GetToDoItemById(string id);
        Task<List<ToDoItem>> GetToDoItemsByToDoListId(string id);
        Task CreateToDoItem(ToDoItem ToDoItem);
        Task UpdateToDoItemAsync(ToDoItem ToDoItem);
        Task DeleteToDoItem(string id);        
    }
}