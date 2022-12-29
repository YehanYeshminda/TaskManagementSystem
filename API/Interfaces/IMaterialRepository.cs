using API.Entities;

namespace API.Interfaces
{
    public interface IMaterialRepository
    {
        Task<IEnumerable<Materials>> GetMaterials();
        Task<Materials> GetMaterialByIdAsync(int id);  
    }
}