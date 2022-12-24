using API.Entities;
using API.Interfaces;

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
            return await _context.WorkShops.FindAsync(id);
        }
    }
}