using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class GrnRepository : IGrnRepository
    {
        private readonly DataContext _context;
        public GrnRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Grn> GetGrnByIdAsync(int id)
        {
            return await _context.Grns
            .Include(s => s.AppUser)
            .SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Grn>> GetGrns()
        {
            return await _context.Grns
            .Include(s => s.AppUser)
            .ToListAsync();
        }
    }
}