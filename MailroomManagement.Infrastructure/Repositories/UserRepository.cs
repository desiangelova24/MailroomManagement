using MailroomManagement.Core.Entities;
using MailroomManagement.Infrastructure.Data.MailroomManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailroomManagement.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task AddAsync(User entity, string createdBy)
        {
            entity.CreatedDate = System.DateTime.UtcNow;
            entity.ModifiedBy = createdBy;
            entity.CreatedBy = createdBy;
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User entity, string modifiedBy)
        {
            entity.ModifiedDate = System.DateTime.UtcNow;
            entity.ModifiedBy = modifiedBy;
            _context.Users.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id, string modifiedBy)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                entity.ModifiedDate = System.DateTime.UtcNow;
                entity.ModifiedBy = modifiedBy;
                _context.Users.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
