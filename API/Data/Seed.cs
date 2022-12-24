using System.Text.Json;
using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using t = System.Threading.Tasks;

namespace API.Data
{
    public class Seed
    {
        public static async t.Task SeedUsers(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, DataContext context)
        {
            if (await userManager.Users.AnyAsync()) return; // if we have any users inside of the data then return

            var userData = await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var users = JsonSerializer.Deserialize<List<AppUser>>(userData); // json data gets parsed in to the method as a app user

            // adding roles to the application
            var roles = new List<AppRole>
            {
                new AppRole{Name = "Member"},
                new AppRole{Name = "WorkshopAndUnitSupervisor"},
                new AppRole{Name = "Admin"},
                new AppRole{Name = "DepartmentSupervisor"},
                new AppRole{Name = "EngineeringDepartmentManager"},
                new AppRole{Name = "SalesMarketingDepartmentManager"},
                new AppRole{Name = "PurchasingDepartmentManager"},
                new AppRole{Name = "FinanceDepartmentManager"},
                new AppRole{Name = "HRDepartmentManager"},
                new AppRole{Name = "FactoryManagementDepartmentManager"},
            };

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }

            foreach (var user in users)
            {
                user.UserName = user.UserName.ToLower();
                await userManager.CreateAsync(user, "Pa$$w0rd");
                await userManager.AddToRoleAsync(user, "Member"); // this will be the default role
            }

            var wordshopSupervisor = new AppUser
            {
                UserName = "WorkshopUnitSupervisor"
            };

            await userManager.CreateAsync(wordshopSupervisor, "Pa$$w0rd");
            await userManager.AddToRolesAsync(wordshopSupervisor, new[] { "WorkshopAndUnitSupervisor" });
        }


        public static async void SeedInformation(ApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DataContext>();

                if (!context.Product.Any())
                {
                    context.Product.AddRange(new Product()
                    {
                        Name = "Product 1",
                        CostPrice = 100,
                        SalePrice = 200,
                        Description = "this is product description",
                        CreatedAt = DateTime.Now,
                    });

                    await context.SaveChangesAsync();
                }

                if (!context.Unit.Any())
                {
                    context.Unit.AddRange(new Unit()
                    {
                        Name = "Unit 1",
                        Description = "this is unit description",
                        Telephone = "123",
                        Email = "test@example.com",
                        CreatedAt = DateTime.Now,
                    });

                    await context.SaveChangesAsync();
                }

                if (!context.WorkShops.Any())
                {
                    context.WorkShops.AddRange(new WorkShop()
                    {
                        Name = "WorkShop 1",
                        Description = "this is a new work shop",
                        Telephone = "123",
                        Email = "test@gmail.com",
                        CreatedAt = DateTime.Now,
                    });

                    await context.SaveChangesAsync();
                }
            }
        }
    }
}