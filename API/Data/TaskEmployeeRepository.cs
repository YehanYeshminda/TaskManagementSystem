using API.Dtos;
using API.Entities;
using API.Helpers;
using API.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class TaskEmployeeRepository : ITaskEmployeeRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public TaskEmployeeRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public void AddTaskEmployee(TaskEmployee taskEmployee)
        {
            _context.TaskEmployees.Add(taskEmployee);
        }

        public void DeleteTaskEmployee(TaskEmployee taskEmployee)
        {
            _context.TaskEmployees.Remove(taskEmployee);
        }

        public async Task<IEnumerable<TaskEmployee>> GetTaskEmployees()
        {
            var query = await _context.TaskEmployees
                .Include(s => s.UserTasks)
                .Include(s => s.AppUser)
                .ToListAsync();

            return query;
        }
        
        public async Task<IEnumerable<UserTasks>> GetTaskEmployeesFilter(TaskEmployeeFilterParams taskEmployeeFilterParams)
        {
            var query = await _context.UserTasks.Where(s => s.EndDate < DateTime.Parse(taskEmployeeFilterParams.EndDate) 
                                                            && s.StartDate > DateTime.Parse(taskEmployeeFilterParams.StartDate))
                .ToListAsync();
            return query;
        }

        public async Task<TaskEmployee> GetTasksEmployeeFromId(int id)
        {
            return await _context.TaskEmployees.FindAsync(id);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}