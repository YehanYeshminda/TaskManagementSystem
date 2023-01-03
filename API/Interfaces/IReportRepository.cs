using API.Dtos;
using API.Helpers;

namespace API.Interfaces
{
    public interface IReportRepository
    {
        Task<IEnumerable<EmployeePerformenceReportDto>> GetEmployeePerformenceReport();
        Task<IEnumerable<InventoryViewReportDto>> GetInventorySummaryReport();
        Task<IEnumerable<IncomeSummaryReportDto>> GetInomeSummaryReport();
        Task<IEnumerable<ProductIncomeDtoReport>> GetProductIncomeSummaryReport();
        Task<IEnumerable<EmployeeSummaryDto>> GetEmployeeSummaryReport();
    }
}