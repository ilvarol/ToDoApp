using Couchbase.Linq;
using System;

namespace ToDoApp.Core.Models
{
    [CouchbaseCollection("todo", "ToDoList")]
    public class ToDoList
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }
        public string userId { get; set; }
    }
}
