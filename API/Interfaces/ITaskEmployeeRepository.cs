using API.Entities;

namespace API.Interfaces
{
    public interface ITaskEmployeeRepository
    {
        void AddTaskEmployee(TaskEmployee taskEmployee);
        void DeleteTaskEmployee(TaskEmployee taskEmployee);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<TaskEmployee>> GetTaskEmployees();
        Task<TaskEmployee> GetTasksEmployeeFromId(int id);
    }
}