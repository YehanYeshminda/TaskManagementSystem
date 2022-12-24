using API.Entities;

namespace API.Interfaces
{
    public interface IWorkshopRepository
    {
        Task<WorkShop> GetWorkshopByIdAsync(int id);
        Task<IEnumerable<WorkShop>> GetWorkshops();
    }
}