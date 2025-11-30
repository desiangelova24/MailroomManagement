using MailroomManagement.Core.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MailroomManagement.Infrastructure.Repositories
{
    public interface IRepository<T> where T : class, IAuditableEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes);
        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdAsync(int id, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes);
        Task AddAsync(T entity, string createdBy);
        Task UpdateAsync(T entity, string modifiedBy);
        Task DeleteAsync(int id, string modifiedBy);
    }
}
