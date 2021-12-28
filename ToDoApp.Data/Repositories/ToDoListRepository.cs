using Couchbase.Extensions.DependencyInjection;
using ToDoApp.Core.Models;
using ToDoApp.Core.Repositories;

namespace ToDoApp.Data.Repositories
{
    public class ToDoListRepository : GenericRepository<ToDoList, CouchbaseContext>, IToDoListRepository
    {
        public ToDoListRepository(INamedBucketProvider bucketProvider) : base(bucketProvider, "todo", nameof(ToDoList))
        {
        }
    }
}
