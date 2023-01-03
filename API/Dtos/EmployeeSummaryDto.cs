using API.Helpers;

namespace API.Dtos
{
    public class EmployeeSummaryDto
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public List<string> EmployeeRole { get; set; }
        public int EmployeeDob { get; set; }
        public string EmployeeNIC { get; set; }
        public string DepartmentName { get; set; }
        public int EmployeeRate { get; set; } = GetRandomNumber.GetRandom();   
        public int EmployeeExperience { get; set; } = GetRandomNumber.GetRandom();
        public List<string> LastPositions { get; set; }
        public int NumOfTimesPromoted { get; set; } = GetRandomNumber.GetRandomMaxTen();
    }
}