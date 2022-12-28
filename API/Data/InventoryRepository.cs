using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly DataContext _context;
        public InventoryRepository(DataContext context)
        {
            _context = context;
        }

        public void AddInventory(Inventory Inventory)
        {
            _context.Inventories.Add(Inventory);
        }

        public void DeleteInventory(Inventory inventory)
        {
            _context.Inventories.Remove(inventory);
        }

        public async Task<IEnumerable<Inventory>> GetInventory()
        {
            return await _context.Inventories
            .Include(s => s.Grn).ThenInclude(s => s.AppUser)
            .Include(s => s.Materials).ThenInclude(s => s.TaskMaterials)
            .Include(s => s.Materials).ThenInclude(s => s.MaterialType)
            .ToListAsync();
        }

        public async Task<Inventory> GetInventoryFromId(int id)
        {
            return await _context.Inventories
            .Include(s => s.Grn).ThenInclude(s => s.AppUser)
            .Include(s => s.Materials).ThenInclude(s => s.TaskMaterials)
            .Include(s => s.Materials).ThenInclude(s => s.MaterialType)
            .SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}