namespace API.Dtos
{
    public class TaskMaterialDto
    {
        public decimal Qty { get; set; }
        public decimal UsedQty { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int UserTasksId { get; set; }
        public int MaterialsId { get; set; }
    }
}