using API.Entities;

namespace API.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductByIdAsync(int id);
    }
}