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
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;

        public DepartmentRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Department>> GetAllWithOrganizationAsync(int organizationId)
        {
            return await _context.Departments.Where(d => d.OrganizationId == organizationId).ToListAsync();
        }
    }
}
