using Couchbase.Linq;
using System;

namespace ToDoApp.Core.Models
{
    [CouchbaseCollection("todo", "ToDoItem")]

    public class ToDoItem
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
