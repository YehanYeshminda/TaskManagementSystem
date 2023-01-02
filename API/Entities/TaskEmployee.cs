namespace API.Entities
{
    public class TaskEmployee
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public AppUser AppUser { get; set; }
        public UserTasks UserTasks { get; set; }        
    }
}