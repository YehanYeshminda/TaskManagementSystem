using API.Entities;

namespace API.Interfaces
{
    public interface ITaskRepository
    {
        void AddTask(UserTasks tasks);
        void DeleteTask(UserTasks tasks);
        Task<bool> SaveAllAsync();
    }
}