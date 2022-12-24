using API.Entities;

namespace API.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetDepartments();
        Task<Department> GetDepartmentByIdAsync(int id);        
    }
}