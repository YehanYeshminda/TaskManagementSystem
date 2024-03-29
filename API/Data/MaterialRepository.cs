using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class MaterialRepository : IMaterialRepository
    {
        private readonly DataContext _context;
        public MaterialRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Materials>> GetMaterials()
        {
            return await _context.Materials
            .Include(s => s.MaterialType).ThenInclude(s => s.Materials)
            .Include(s => s.TaskMaterials)
            .ToListAsync();
        }

        public async Task<Materials> GetMaterialByIdAsync(int id)
        {
            return await _context.Materials
            .Include(s => s.MaterialType)
            .Include(s => s.TaskMaterials)
            .SingleOrDefaultAsync(s => s.Id == id);
        }
    }
}