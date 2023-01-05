using API.Dtos;
using API.Helpers;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ReportController : BaseApiController
    {
        private readonly IReportRepository _reportRepository;
        public ReportController(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        [HttpGet("EmployeePerformance")]
        public async Task<IEnumerable<EmployeePerformenceReportDto>> GetEmployeePerformencesAsync()
        {
            return await _reportRepository.GetEmployeePerformenceReport();
        }

        [HttpGet("InventorySummary")]
        public async Task<IEnumerable<InventoryViewReportDto>> GetInventorySummaryAsync()
        {
            return await _reportRepository.GetInventorySummaryReport();
        }

        [HttpGet("IncomeSummary")]
        public async Task<IEnumerable<IncomeSummaryReportDto>> GetIncomeSummaryAsync()
        {
            return await _reportRepository.GetInomeSummaryReport();
        }

        [HttpGet("IncomeReport")]
        public async Task<IEnumerable<ProductIncomeDtoReport>> GetIncomeReportAsync()
        {
            return await _reportRepository.GetProductIncomeSummaryReport();
        }

        [HttpGet("EmpSummary")]
        public async Task<IEnumerable<EmployeeSummaryDto>> GetEmployeeReportAsync()
        {
            return await _reportRepository.GetEmployeeSummaryReport();
        }

        [HttpGet("ProductReport")]
        public async Task<IEnumerable<ProductDto>> ProductReportAsync()
        {
            return await _reportRepository.GetProductReport();
        }

        [HttpGet("WorkshopProductionReport")]
        public async Task<IEnumerable<WorkshopProductionDto>> WorkshopProductionReportAsync()
        {
            return await _reportRepository.GetWorkshopProductionReport();
        }
    }
}