using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class WorkshopRepository : IWorkshopRepository
    {
        private readonly DataContext _context;
        public WorkshopRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<WorkShop> GetWorkshopByIdAsync(int id)
        {
            return await _context.WorkShops.Include(s => s.UserTasks).SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<WorkShop>> GetWorkshops()
        {
            return await _context.WorkShops
            .Include(s => s.Department)
            .Include(s => s.UserTasks)
            .ToListAsync();
        }
    }
}