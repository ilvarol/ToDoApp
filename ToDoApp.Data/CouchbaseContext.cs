using Couchbase;
using Couchbase.Linq;
using ToDoApp.Core.Models;

namespace ToDoApp.Data
{
    public class CouchbaseContext : BucketContext
    {
        public CouchbaseContext(IBucket bucket) : base(bucket)
        {
        }

        public IDocumentSet<User> User { get; set; }
        public IDocumentSet<ToDoList> ToDoList { get; set; }
        public IDocumentSet<ToDoItem> ToDoItem { get; set; }
    }
}
