using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Product
            .Include(s => s.UserTasks)
            .SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Product
            .Include(s => s.UserTasks)
            .ToListAsync();
        }
    }
}