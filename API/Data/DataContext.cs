using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : IdentityDbContext<AppUser, AppRole, int, IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Department> Departments {get; set;}
        public DbSet<WorkShop> WorkShops { get; set;}
        public DbSet<UserTasks> UserTasks { get; set;}
        public DbSet<Product> Product { get; set;}
        public DbSet<Unit> Unit { get; set;}
        public DbSet<Materials> Materials { get; set;}
        public DbSet<MaterialType> MaterialTypes { get; set;}
        public DbSet<TaskMaterial> taskMaterials { get; set;}
        public DbSet<Grn> Grns { get; set;}
        public DbSet<Inventory> Inventories { get; set;}
        public DbSet<TaskEmployee> TaskEmployees { get; set;}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>()
            .HasMany(u => u.UserRoles)
            .WithOne(u => u.User)
            .HasForeignKey(u => u.UserId)
            .IsRequired();

            builder.Entity<AppRole>()
            .HasMany(u => u.UserRoles)
            .WithOne(u => u.Role)
            .HasForeignKey(u => u.RoleId)
            .IsRequired();
        }
    }
}