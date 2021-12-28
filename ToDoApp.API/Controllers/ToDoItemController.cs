using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.API.DTOs.ToDoItem;
using ToDoApp.API.Models;
using ToDoApp.Core.Models;
using ToDoApp.Core.Services;

namespace ToDoApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemController : ControllerBase
    {
        private readonly IToDoItemService _toDoItemService;
        private readonly IMapper _mapper;

        public ToDoItemController(IToDoItemService toDoItemService, IMapper mapper)
        {
            _toDoItemService = toDoItemService;
            _mapper = mapper;
        }

        [HttpPost("CreateToDoItem")]
        public async Task<IActionResult> CreateToDoItem(ToDoItemCreate toDoItemCreate)
        {
            await _toDoItemService.CreateToDoItem(_mapper.Map<ToDoItem>(toDoItemCreate));

            return Ok(new ResponseObjectModel<ToDoItemCreate>
            {
                Success = true,
                StatusCode = 200,
                Message = $"successful",
                Response = null
            });
        }

        [HttpDelete("DeleteToDoItem/{id}")]
        public async Task<IActionResult> DeleteToDoItemAsync(string id)
        {
            var toDoItem = await _toDoItemService.GetToDoItemById(id);
            if (toDoItem == null)
            {
                return NotFound(new ResponseObjectModel<string>
                {
                    Success = false,
                    StatusCode = 404,
                    Message = $"Not Found!",
                    Response = null
                });
            }
            await _toDoItemService.DeleteToDoItem(id);

            return Ok(new ResponseObjectModel<string>
            {
                Success = true,
                StatusCode = 200,
                Message = $"Successful",
                Response = null
            });
        }

        [HttpGet("GetToDoItemById/{id}")]
        public async Task<IActionResult> GetToDoItemByIdAsync(string id)
        {
            var toDoItem = await _toDoItemService.GetToDoItemById(id);
            if (toDoItem == null)
            {
                return NotFound(new ResponseObjectModel<ToDoItem>
                {
                    Success = false,
                    StatusCode = 404,
                    Message = $"Not Found!",
                    Response = null
                });
            }

            return Ok(new ResponseObjectModel<ToDoItem>
            {
                Success = true,
                StatusCode = 200,
                Message = "Successful!",
                Response = _mapper.Map<ToDoItem>(toDoItem)
            });
        }

        [HttpGet("GetToDoItemByToDoListId")]
        public async Task<IActionResult> GetToDoItemByToDoListIdAsync(string id)
        {
            var toDoItem = await _toDoItemService.GetToDoItemsByToDoListId(id);
            if (toDoItem == null)
            {
                return NotFound(new ResponseObjectModel<ToDoItem>
                {
                    Success = false,
                    StatusCode = 404,
                    Message = $"Not Found!",
                    Response = null
                });
            }

            return Ok(new ResponseListModel<ToDoItem>
            {
                Success = true,
                StatusCode = 200,
                Message = "Successful!",
                Response = _mapper.Map<List<ToDoItem>>(toDoItem)
            });
        }

        [HttpGet("GetToDoItems")]
        public IActionResult GetToDoItems()
        {
            var toDoItems = _toDoItemService
                .GetToDoItemsAsync().Result
                .Select(_mapper.Map<ToDoItem, ToDoItemRead>)
                .ToList();

            return Ok(new ResponseListModel<ToDoItemRead>
            {
                Success = true,
                StatusCode = 200,
                Message = "Successful!",
                Response = toDoItems
            });
        }

        [HttpPut("UpdateToDoItem")]
        public async Task<IActionResult> UpdateToDoItemAsync(ToDoItemUpdate toDoItemUpdate)
        {
            await _toDoItemService.UpdateToDoItemAsync(_mapper.Map<ToDoItem>(toDoItemUpdate));

            return Ok(new ResponseObjectModel<ToDoItemUpdate>
            {
                Success = true,
                StatusCode = 200,
                Message = $"successful!",
                Response = null
            });
        }
    }
}