namespace API.Entities
{
    public class UserTasks
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CustomerDetails { get; set; }
        public int Qty { get; set; }
        public string Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public Department Department { get; set; }
        public WorkShop WorkShop { get; set; }
        public AppUser AppUser { get; set; }
        public Unit Unit { get; set; }
        public Product Product { get; set; }
    }
}