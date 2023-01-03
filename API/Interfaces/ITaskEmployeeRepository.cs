using API.Dtos;
using API.Entities;
using API.Helpers;

namespace API.Interfaces
{
    public interface ITaskEmployeeRepository
    {
        void AddTaskEmployee(TaskEmployee taskEmployee);
        void DeleteTaskEmployee(TaskEmployee taskEmployee);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<TaskEmployee>> GetTaskEmployees();
        Task<TaskEmployee> GetTasksEmployeeFromId(int id);
        Task<IEnumerable<UserTasks>> GetTaskEmployeesFilter(TaskEmployeeFilterParams taskEmployeeFilterParams);
    }
}