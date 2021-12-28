using Couchbase.Extensions.DependencyInjection;
using ToDoApp.Core.Models;
using ToDoApp.Core.Repositories;

namespace ToDoApp.Data.Repositories
{
    public class UserRepository : GenericRepository<User, CouchbaseContext>, IUserRepository
    {
        public UserRepository(INamedBucketProvider bucketProvider) : base(bucketProvider, "user", nameof(User))
        {
        }
    }
}
