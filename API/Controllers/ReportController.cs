using API.Dtos;
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
    }
}