using API.Dtos;
using API.Helpers;
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

        public async Task<IEnumerable<EmployeeSummaryDto>> GetEmployeeSummaryReport()
        {
            var query = await _context.TaskEmployees
                .Include(s => s.AppUser).ThenInclude(s => s.UserRoles).ThenInclude(s => s.Role)
                .Include(s => s.AppUser.Departments)
                .ToListAsync();

            return _mapper.Map<IEnumerable<EmployeeSummaryDto>>(query);
        }

        public async Task<IEnumerable<IncomeSummaryReportDto>> GetInomeSummaryReport()
        {
            var query = await _context.Product
                .Include(s => s.UserTasks)
                .ToListAsync();

            return _mapper.Map<IEnumerable<IncomeSummaryReportDto>>(query);
        }

        public async Task<IEnumerable<InventoryViewReportDto>> GetInventorySummaryReport()
        {
            var query = await _context.Inventories
                .Include(s => s.Grn)
                .Include(s => s.Materials)
                .ToListAsync();

            return _mapper.Map<IEnumerable<InventoryViewReportDto>>(query);
        }

        public async Task<IEnumerable<ProductIncomeDtoReport>> GetProductIncomeSummaryReport()
        {
            var query = await _context.Product.
                Include(s => s.UserTasks)
                .ToListAsync();

            return _mapper.Map<IEnumerable<ProductIncomeDtoReport>>(query);
        }

        public async Task<IEnumerable<ProductDto>> GetProductReport()
        {
            var query = await _context.Product.
                Include(s => s.UserTasks)
                .ToListAsync();

            return _mapper.Map<IEnumerable<ProductDto>>(query);
        }

        public async Task<IEnumerable<WorkshopProductionDto>> GetWorkshopProductionReport()
        {
            var query = await _context.WorkShops.
                Include(s => s.UserTasks)
                .ToListAsync();

            return _mapper.Map<IEnumerable<WorkshopProductionDto>>(query);
        }
    }
}