namespace API.Dtos
{
    public class ProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CostPrice { get; set; }
        public int SalePrice { get; set; }
        public int NumberOfSales { get; set; }  
    }
}
