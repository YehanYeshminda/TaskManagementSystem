namespace API.Entities
{
    public class Grn
    {
        public int Id { get; set; }
        public string GrnNo { get; set; }
        public DateTime GrnDate { get; set; }
        public AppUser AppUser { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }        
    }
}