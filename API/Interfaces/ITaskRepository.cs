using API.Dtos;
using API.Entities;

namespace API.Interfaces
{
    public interface ITaskRepository
    {
        void AddTask(UserTasks tasks);
        void DeleteTask(UserTasks tasks);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<TaskDto>> GetTasks();
        Task<UserTasks> GetTasksFromId(int id);
    }
}