using API.Entities;

namespace API.Interfaces
{
    public interface IInventoryRepository
    {
        void AddInventory(Inventory inventory);
        void DeleteInventory(Inventory inventory);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<Inventory>> GetInventory();
        Task<Inventory> GetInventoryFromId(int id);
    }
}