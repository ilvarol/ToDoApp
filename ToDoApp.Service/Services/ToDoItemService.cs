using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.Core.Models;
using ToDoApp.Core.Repositories;
using ToDoApp.Core.Services;

namespace ToDoApp.Service.Services
{
    public class ToDoItemService : IToDoItemService
    {
        private readonly IToDoItemRepository _toDoItemRepository;

        public ToDoItemService(IToDoItemRepository toDoItemRepository)
        {
            _toDoItemRepository = toDoItemRepository;
        }

        public async Task CreateToDoItem(ToDoItem ToDoItem)
        {
            ToDoItem.Id = Guid.NewGuid().ToString();

            await _toDoItemRepository.CreateAsync(ToDoItem.Id, ToDoItem);
        }

        public async Task DeleteToDoItem(string id)
        {
            await _toDoItemRepository.Delete(id);
        }

        public async Task<ToDoItem> GetToDoItemById(string id)
        {
            return await _toDoItemRepository.GetOne(x => x.Id == id);
        }

        public async Task<List<ToDoItem>> GetToDoItemsByToDoListId(string id)
        {
            return await _toDoItemRepository.GetAll(x => x.toDoListId == id);
        }

        public async Task<List<ToDoItem>> GetToDoItemsAsync()
        {
            return await _toDoItemRepository.GetAll(null);
        }

        public async Task UpdateToDoItemAsync(ToDoItem ToDoItem)
        {
            ToDoItem.Id = Guid.NewGuid().ToString();

            await _toDoItemRepository.UpdateAsync(ToDoItem.Id, ToDoItem);
        }
    }
}