namespace API.Dtos
{
    public class ProductIncomeDtoReport
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SalesPrice { get; set; }
        public List<decimal> Qty { get; set; }
        public decimal SingleProfit { get; set; }
        public string StartDate { get; set; }        
        public string EndDate { get; set; }        
    }
}