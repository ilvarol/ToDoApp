using Couchbase.Extensions.DependencyInjection;
using ToDoApp.Core.Models;
using ToDoApp.Core.Repositories;

namespace ToDoApp.Data.Repositories
{
    public class ToDoItemRepository : GenericRepository<ToDoItem, CouchbaseContext>, IToDoItemRepository
    {
        public ToDoItemRepository(INamedBucketProvider bucketProvider) : base(bucketProvider, "todo", nameof(ToDoItem))
        {
        }
    }
}
