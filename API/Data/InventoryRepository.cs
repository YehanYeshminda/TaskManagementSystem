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
            return await _context.Inventories.ToListAsync();
        }

        public async Task<Inventory> GetInventoryFromId(int id)
        {
            return await _context.Inventories.FindAsync(id);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}