namespace API.Dtos
{
    public class TaskUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CustomerDetails { get; set; }
        public int Qty { get; set; }
        public string Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string DepartmentName { get; set; }
        public string WorkShopName { get; set; }
        public string AppUserName { get; set; }
        public string UnitName { get; set; }
        public string ProductName { get; set; }
    }
}