using API.Entities;

namespace API.Interfaces
{
    public interface IUnitRepository
    {
        Task<IEnumerable<UnitDto>> GetUnits();
        Task<Unit> GetUnitByIdAsync(int id);  
    }
}