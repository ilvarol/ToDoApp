using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.API.DTOs.ToDoList;
using ToDoApp.API.Models;
using ToDoApp.Core.Models;
using ToDoApp.Core.Services;

namespace ToDoApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        private readonly IToDoListService _toDoListService;
        private readonly IMapper _mapper;

        public ToDoListController(IToDoListService toDoListService, IMapper mapper)
        {
            _toDoListService = toDoListService;
            _mapper = mapper;
        }

        [HttpPost("CreateToDoList")]
        public async Task<IActionResult> CreateToDoListAsync(ToDoListCreate toDoListCreate)
        {
            await _toDoListService.CreateToDoList(_mapper.Map<ToDoList>(toDoListCreate));

            return Ok(new ResponseObjectModel<ToDoListCreate>
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
            var toDoList = await _toDoListService.GetToDoListById(id);
            if (toDoList == null)
            {
                return NotFound(new ResponseObjectModel<string>
                {
                    Success = false,
                    StatusCode = 404,
                    Message = $"Not Found!",
                    Response = null
                });
            }
            await _toDoListService.DeleteToDoList(id);

            return Ok(new ResponseObjectModel<string>
            {
                Success = true,
                StatusCode = 200,
                Message = $"Successful!",
                Response = null
            });
        }

        [HttpGet("GetToDoListById/{id}")]
        public async Task<IActionResult> GetToDoListByIdAsync(string id)
        {
            var toDoList = await _toDoListService.GetToDoListById(id);
            if (toDoList == null)
            {
                return NotFound(new ResponseObjectModel<ToDoList>
                {
                    Success = false,
                    StatusCode = 404,
                    Message = $"Not Found!",
                    Response = null
                });
            }

            return Ok(new ResponseObjectModel<ToDoList>
            {
                Success = true,
                StatusCode = 200,
                Message = "Successful!",
                Response = _mapper.Map<ToDoList>(toDoList)
            });
        }

        [HttpGet("GetToDoLists")]
        public IActionResult GetToDoLists()
        {
            var toDoItems = _toDoListService
                .GetToDoLists().Result
                .Select(_mapper.Map<ToDoList, ToDoListRead>)
                .ToList();

            return Ok(new ResponseListModel<ToDoListRead>
            {
                Success = true,
                StatusCode = 200,
                Message = "Successful!",
                Response = toDoItems
            });
        }

        [HttpPut("UpdateToDoList")]
        public async Task<IActionResult> UpdateToDoListAsync(ToDoListUpdate toDoListUpdate)
        {
            await _toDoListService.UpdateToDoList(_mapper.Map<ToDoList>(toDoListUpdate));

            return Ok(new ResponseObjectModel<ToDoListUpdate>
            {
                Success = true,
                StatusCode = 200,
                Message = $"successful!",
                Response = null
            });
        }
    }
}