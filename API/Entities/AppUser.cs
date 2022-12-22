using Microsoft.AspNetCore.Identity;

namespace API.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string NIC { get; set; }
        public string Address { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public Department Departments { get; set; }
        public ICollection<AppUserRole> UserRoles { get; set; }
        public ICollection<UserTasks> UserTasks { get; set; }
    }
}