namespace API.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DepartmentNo { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public ICollection<AppUser> AppUsers { get; set; }
        public ICollection<WorkShop> WorkShops { get; set; }
        public ICollection<UserTasks> UserTasks { get; set; }
        public ICollection<Unit> Units { get; set; }
        public Company Companys { get; set; }
        public Factory Factorys { get; set; }
    }
}