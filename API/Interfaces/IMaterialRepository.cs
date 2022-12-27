using API.Entities;

namespace API.Interfaces
{
    public interface IMaterialRepository
    {
        Task<Materials> GetMaterialByIdAsync(int id);  
    }
}