using System;

namespace ToDoApp.API.DTOs.ToDoItem
{
    public class ToDoItemUpdate
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool Completed { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }
        public string toDoListId { get; set; }

    }
}
