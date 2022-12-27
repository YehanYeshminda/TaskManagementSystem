namespace API.Dtos
{
    public class TaskUpdateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CustomerDetails { get; set; }
        public int Qty { get; set; }
        public string Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public int ProductId { get; set; }
    }
}