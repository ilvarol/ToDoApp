using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.Core.Models;
using ToDoApp.Core.Repositories;
using ToDoApp.Core.Services;

namespace ToDoApp.Service.Services
{
    public class ToDoListService : IToDoListService
    {
        private readonly IToDoListRepository _toDoListRepository;

        public ToDoListService(IToDoListRepository toDoListRepository)
        {
            _toDoListRepository = toDoListRepository;
        }

        public async Task CreateToDoList(ToDoList toDoList)
        {
            toDoList.Id = Guid.NewGuid().ToString();

            await _toDoListRepository.CreateAsync(toDoList.Id, toDoList);
        }

        public async Task DeleteToDoList(string id)
        {
            await _toDoListRepository.Delete(id);
        }

        public async Task<ToDoList> GetToDoListById(string id)
        {
            return await _toDoListRepository.GetOne(x => x.Id == id);
        }

        public async Task<List<ToDoList>> GetToDoLists()
        {
            return await _toDoListRepository.GetAll(null);
        }

        public async Task UpdateToDoList(ToDoList toDoList)
        {
            toDoList.Id = Guid.NewGuid().ToString();

            await _toDoListRepository.UpdateAsync(toDoList.Id, toDoList);
        }
    }
}