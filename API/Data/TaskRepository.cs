using API.Dtos;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public TaskRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
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

        public async Task<IEnumerable<TaskDto>> GetTasks()
        {
            var query = await _context.UserTasks
            .Include(d => d.Department)
            .Include(w => w.WorkShop)
            .Include(a => a.AppUser)
            .Include(u => u.Unit)
            .Include(p => p.Product)
            .Include(s => s.TaskMaterials).ThenInclude(s => s.Materials)
            .OrderBy(c => c.CreatedAt)
            .ToListAsync();

            return _mapper.Map<IEnumerable<TaskDto>>(query);
        }

        public async Task<UserTasks> GetTasksFromId(int id)
        {
            return await _context.UserTasks.FindAsync(id);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}