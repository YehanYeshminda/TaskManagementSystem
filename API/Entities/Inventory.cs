namespace API.Entities
{
    public class Inventory
    {
        public int Id { get; set; }
        public decimal Qty { get; set; }
        public decimal AvailableQty { get; set; }
        public decimal UnitCost { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }  
        public Materials Materials { get; set; }
        public Grn Grn { get; set; }        
    }
}