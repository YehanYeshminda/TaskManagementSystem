using API.Helpers;

namespace API.Dtos
{
    public class IncomeSummaryReportDto
    {
        public string ProductName { get; set; }
        public List<decimal> SoldQty { get; set; }
        public decimal ProductCost { get; set; }
        public decimal SoldPrice { get; set; }
        public decimal Profit { get; set; } 
    }
}