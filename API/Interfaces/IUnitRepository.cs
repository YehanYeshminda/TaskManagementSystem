using API.Entities;

namespace API.Interfaces
{
    public interface IUnitRepository
    {
        Task<Unit> GetUnitByIdAsync(int id);        
    }
}