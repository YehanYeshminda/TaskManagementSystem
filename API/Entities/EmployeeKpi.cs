namespace API.Entities
{
    public class EmployeeKpi
    {
        public int Id { get; set; }
        public decimal DailyTarget { get; set; }
        public decimal WeeklyTarget { get; set; }
        public decimal MonthlyTarget { get; set; }
        public AppUser AppUser { get; set; }
        public Product Product { get; set; }
    }
}