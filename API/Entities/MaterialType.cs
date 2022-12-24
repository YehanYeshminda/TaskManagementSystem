namespace API.Entities
{
    public class MaterialType
    {
        public int Id { get; set; }
        public string Name { get; set; }        
        public string Code { get; set; }        
        public string Description { get; set; }        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public ICollection<Materials> Materials { get; set; } 
    }
}