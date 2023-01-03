using API.Helpers;

namespace API.Dtos
{
    public class EmployeePerformenceReportDto
    {
        public string AppUserName { get; set; }          
        public List<string> AppUserRole { get; set; }
        public List<decimal> DailyTarget { get; set; }            
        public List<decimal> WeeklyTarget { get; set; }            
        public List<decimal> MonthlyTarget { get; set; }   
        public string DepartmentName { get; set; }         
        public decimal EmployeeRate { get; set; } = GetRandomNumber.GetRandom();   
    }
}