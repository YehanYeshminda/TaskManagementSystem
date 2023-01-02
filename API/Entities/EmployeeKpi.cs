namespace API.Entities
{
    public class EmployeeKpi
    {
        public int Id { get; set; }
        public decimal DailyTarget { get; set; }
        public decimal WeeklyTarget { get; set; }
        public decimal MonthlyTarget { get; set; }
        public AppUserRole UserRoles { get; set; }
        public Product Product { get; set; }
    }
}