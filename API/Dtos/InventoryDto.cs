using API.Entities;

namespace API.Dtos
{
    public class InventoryDto
    {
        public decimal Qty { get; set; }
        public decimal AvailableQty { get; set; }
        public decimal UnitCost { get; set; }    
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}