using API.Dtos;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ReportRepository : IReportRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ReportRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        
        public async Task<IEnumerable<EmployeePerformenceReportDto>> GetEmployeePerformenceReport()
        {   
            var query = await _context.TaskEmployees
                .Include(s => s.AppUser).ThenInclude(s => s.EmployeeKpis)
                .Include(s => s.AppUser).ThenInclude(s => s.Departments)
                .Include(s => s.AppUser).ThenInclude(s => s.UserRoles).ThenInclude(s => s.Role)
                .Include(s => s.UserTasks)
                .ToListAsync();
            return _mapper.Map<IEnumerable<EmployeePerformenceReportDto>>(query);
        }
    }
}