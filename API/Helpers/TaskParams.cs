namespace API.Helpers
{
    public class TaskParams
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CustomerDetails { get; set; }
        public int Qty { get; set; }
        public string Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int DepartmentId { get; set; }
        public int WorkshopId { get; set; }
        public int AppUserId { get; set; }
        public int UnitId { get; set; }
        public int ProductId { get; set; }   
    }
}