using Couchbase;
using Couchbase.Extensions.DependencyInjection;
using Couchbase.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ToDoApp.Core.Repositories;

namespace ToDoApp.Data.Repositories
{
    public class GenericRepository<T, TContext> : IRepositoryBase<T>
    where T : class
    where TContext : CouchbaseContext
    {
        private readonly INamedBucketProvider _bucketProvider;
        private readonly string _scopeName;
        private readonly string _collectionName;

        public GenericRepository(INamedBucketProvider bucketProvider, string scopeName, string collectionName)
        {
            _bucketProvider = bucketProvider;
            _scopeName = scopeName;
            _collectionName = collectionName;
        }

        public virtual async Task CreateAsync(string id, T entity)
        {
            var bucket = await _bucketProvider.GetBucketAsync();
            await bucket.Scope(_scopeName).Collection(_collectionName).InsertAsync(id, entity);
        }

        public virtual async Task Delete(string id)
        {
            var bucket = await _bucketProvider.GetBucketAsync();
            await bucket.Scope(_scopeName).Collection(_collectionName).RemoveAsync(id);
        }

        public virtual async Task<List<T>> GetAll(Expression<Func<T, bool>> filter = null)
        {
            var context = new CouchbaseContext(await _bucketProvider.GetBucketAsync());

            return filter == null
                     ? context.Query<T>().ToList()
                     : context.Query<T>().Where(filter).ToList();
        }

        public virtual async Task<T> GetOne(Expression<Func<T, bool>> filter)
        {
            var context = new CouchbaseContext(await _bucketProvider.GetBucketAsync());

            return context.Query<T>()
                .Where(filter)
                .SingleOrDefault();
        }

        public virtual async Task UpdateAsync(string id, T entity)
        {
            var bucket = await _bucketProvider.GetBucketAsync();
            await bucket.Scope(_scopeName).Collection(_collectionName).UpsertAsync(id, entity);
        }
    }
}
