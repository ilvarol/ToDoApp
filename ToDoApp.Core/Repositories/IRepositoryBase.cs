using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ToDoApp.Core.Repositories
{
    public interface IRepositoryBase<T>
    {
        Task<T> GetOne(Expression<Func<T, bool>> filter);
        Task<List<T>> GetAll(Expression<Func<T, bool>> filter = null);

        Task CreateAsync(string id, T entity);
        Task UpdateAsync(string id, T entity);
        Task Delete(string id);
    }
}
