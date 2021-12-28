using Couchbase.Linq;
using System;

namespace ToDoApp.Core.Models
{
    [CouchbaseCollection("user", "User")]
    public class User
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
