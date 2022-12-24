using API.Entities;

namespace API.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<Department> GetDepartmentByIdAsync(int id);        
    }
}