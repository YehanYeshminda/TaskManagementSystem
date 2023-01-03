namespace API.Dtos
{
    public class InventoryViewReportDto
    {
        public int Id { get; set; }
        public string MaterialName { get; set; }        
        public string MaterialCode { get; set; }        
        public int AvailableQty { get; set; }
        public int Qty { get; set; }        
        public int UnitCost { get; set; }        
        public string GrnId { get; set; }        
        public string ReOrderLevel { get; set; }        
        public DateTime GrnDate { get; set; }        
    }
}