using API.Entities;
using API.Interfaces;

namespace API.Data
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DataContext _context;
        public TaskRepository(DataContext context)
        {
            _context = context;
        }

        public void AddTask(UserTasks tasks)
        {
            _context.UserTasks.Add(tasks);
        }

        public void DeleteTask(UserTasks tasks)
        {
            _context.UserTasks.Remove(tasks);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}