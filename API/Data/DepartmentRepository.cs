using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DataContext _context;
        public DepartmentRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Department> GetDepartmentByIdAsync(int id)
        {
            return await _context.Departments
            .Include(s => s.AppUsers)
            .Include(s => s.WorkShops)
            .Include(s => s.UserTasks)
            .Include(s => s.Units)
            .Include(s => s.Companys)
            .Include(s => s.Factorys)
            .SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await _context.Departments
            .Include(s => s.AppUsers)
            .Include(s => s.WorkShops)
            .Include(s => s.UserTasks)
            .Include(s => s.Units)
            .Include(s => s.Companys)
            .Include(s => s.Factorys)
            .ToListAsync();
        }
    }
}