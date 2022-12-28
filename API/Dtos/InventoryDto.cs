using API.Entities;

namespace API.Dtos
{
    public class InventoryDto
    {
        public int Id { get; set; }
        public decimal Qty { get; set; }
        public decimal AvailableQty { get; set; }
        public decimal UnitCost { get; set; }
        public Materials Materials { get; set; }
        public Grn Grn { get; set; }       
    }
}