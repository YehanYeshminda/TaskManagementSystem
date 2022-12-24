using API.Entities;
using API.Interfaces;

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
            return await _context.Departments.FindAsync(id);
        }
    }
}