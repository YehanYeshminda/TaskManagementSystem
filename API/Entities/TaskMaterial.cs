namespace API.Entities
{
    public class TaskMaterial
    {
        public int Id { get; set; }
        public decimal Qty { get; set; }
        public decimal UsedQty { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public UserTasks UserTasks { get; set; }
        public Materials Materials { get; set; }
    }
}