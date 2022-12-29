namespace API.Dtos
{
    public class TaskUpdateDto
    {
        public int Qty { get; set; }
        public string Status { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}