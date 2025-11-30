using MailroomManagement.Core.Entities;
using MailroomManagement.Infrastructure.Data.MailroomManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


    namespace MailroomManagement.Infrastructure.Repositories
    {
    public class Repository<T> : IRepository<T> where T : class, IAuditableEntity
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        {
            IQueryable<T> query = _dbSet;
            if (includes != null)
                query = includes(query);
            return await query.Where(predicate).ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> GetByIdAsync(int id, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        {
            IQueryable<T> query = _dbSet;
            if (includes != null)
                query = includes(query);
            return await query.FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
        }

        public async Task AddAsync(T entity, string createdBy)
        {
            entity.CreatedDate = DateTime.UtcNow;
            entity.CreatedBy = createdBy;
            entity.ModifiedBy = createdBy;
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity, string modifiedBy)
        {
            entity.ModifiedDate = DateTime.UtcNow;
            entity.ModifiedBy = modifiedBy;
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id, string modifiedBy)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                entity.ModifiedDate = DateTime.UtcNow;
                entity.ModifiedBy = modifiedBy;
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}


