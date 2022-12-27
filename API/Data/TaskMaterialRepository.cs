using API.Dtos;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class TaskMaterialRepository : ITaskMaterialRepository
    {
        private readonly DataContext _context;
        public TaskMaterialRepository(DataContext context)
        {
            _context = context;
        }

        public void AddTask(TaskMaterial taskMaterials)
        {
            _context.taskMaterials.Add(taskMaterials);
        }

        public void DeleteTask(TaskMaterial taskMaterials)
        {
            _context.taskMaterials.Remove(taskMaterials);
        }

        public async Task<IEnumerable<TaskMaterial>> GetTaskMaterials()
        {
            return await _context.taskMaterials
            .Include(s => s.UserTasks).ThenInclude(s => s.Department)
            .Include(s => s.UserTasks).ThenInclude(s => s.WorkShop)
            .Include(s => s.UserTasks).ThenInclude(s => s.AppUser)
            .Include(s => s.UserTasks).ThenInclude(s => s.Unit)
            .Include(s => s.UserTasks).ThenInclude(s => s.Product)
            .Include(s => s.Materials).ThenInclude(s => s.MaterialType)
            .ToListAsync();
        }

        public async Task<TaskMaterial> GetTaskMaterialsFromId(int id)
        {
            return await _context.taskMaterials.FindAsync(id);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}