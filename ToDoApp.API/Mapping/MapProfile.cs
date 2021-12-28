using AutoMapper;
using ToDoApp.API.DTOs.ToDoItem;
using ToDoApp.API.DTOs.ToDoList;
using ToDoApp.API.DTOs.User;
using ToDoApp.Core.Models;
namespace ToDoApp.API.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<User, UserCreate>().ReverseMap();
            CreateMap<User, UserRead>().ReverseMap();
            CreateMap<User, UserUpdate>().ReverseMap();

            CreateMap<ToDoItem, ToDoItemCreate>().ReverseMap();
            CreateMap<ToDoItem, ToDoItemRead>().ReverseMap();
            CreateMap<ToDoItem, ToDoItemUpdate>().ReverseMap();

            CreateMap<ToDoList, ToDoListCreate>().ReverseMap();
            CreateMap<ToDoList, ToDoListRead>().ReverseMap();
            CreateMap<ToDoList, ToDoListUpdate>().ReverseMap();
        }
    }
}
