namespace API.Helpers
{
    public class InventoryParams
    {
        public decimal Qty { get; set; }
        public decimal AvailableQty { get; set; }
        public decimal UnitCost { get; set; }
        public int MaterialsId { get; set; }
        public int GrnId { get; set; }     
    }
}