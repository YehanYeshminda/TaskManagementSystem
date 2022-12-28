namespace API.Dtos
{
    public class UpdateTaskMaterialDto
    {
        public decimal Qty { get; set; }
        public decimal UsedQty { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}