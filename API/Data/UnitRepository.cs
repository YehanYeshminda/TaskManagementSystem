using API.Entities;
using API.Interfaces;

namespace API.Data
{
    public class UnitRepository : IUnitRepository
    {
        private readonly DataContext _context;
        public UnitRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Unit> GetUnitByIdAsync(int id)
        {
            return await _context.Unit.FindAsync(id);
        }
    }
}