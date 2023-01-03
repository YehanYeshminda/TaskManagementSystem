using API.Dtos;

namespace API.Interfaces
{
    public interface IReportRepository
    {
        Task<IEnumerable<EmployeePerformenceReportDto>> GetEmployeePerformenceReport();
    }
}