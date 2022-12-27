using API.Dtos;
using API.Entities;

namespace API.Interfaces
{
    public interface ITaskMaterialRepository
    {
        void AddTask(TaskMaterial tasks);
        void DeleteTask(TaskMaterial tasks);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<TaskMaterial>> GetTaskMaterials();
        Task<TaskMaterial> GetTaskMaterialsFromId(int id);
    }
}