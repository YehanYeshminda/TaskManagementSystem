using System.Text.Json;
using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using t = System.Threading.Tasks; 

namespace API.Data
{
    public class Seed
    {
        public static async t.Task SeedUsers(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            if (await userManager.Users.AnyAsync()) return; // if we have any users inside of the data then return

            var userData = await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");

            var options = new JsonSerializerOptions{PropertyNameCaseInsensitive = true};

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
            await userManager.AddToRolesAsync(wordshopSupervisor, new[] {"WorkshopAndUnitSupervisor"});

            var admin = new AppUser
            {
                UserName = "Admin"
            };

            await userManager.CreateAsync(admin, "Pa$$w0rd");
            await userManager.AddToRolesAsync(admin, new[] {"Admin"});

            var departmentSupervisor = new AppUser
            {
                UserName = "DepartmentSupervisor"
            };

            await userManager.CreateAsync(departmentSupervisor, "Pa$$w0rd");
            await userManager.AddToRolesAsync(departmentSupervisor, new[] {"DepartmentSupervisor"});

            var engineeringDepartmentManager = new AppUser
            {
                UserName = "EngineeringDepartmentManager"
            };

            await userManager.CreateAsync(engineeringDepartmentManager, "Pa$$w0rd");
            await userManager.AddToRolesAsync(engineeringDepartmentManager, new[] {"EngineeringDepartmentManager"});

            var salesMarketingDepartmentManager = new AppUser
            {
                UserName = "SalesMarketingDepartmentManager"
            };

            await userManager.CreateAsync(salesMarketingDepartmentManager, "Pa$$w0rd");
            await userManager.AddToRolesAsync(salesMarketingDepartmentManager, new[] {"SalesMarketingDepartmentManager"});

            var purchasingDepartmentManager = new AppUser
            {
                UserName = "PurchasingDepartmentManager"
            };

            await userManager.CreateAsync(purchasingDepartmentManager, "Pa$$w0rd");
            await userManager.AddToRolesAsync(purchasingDepartmentManager, new[] {"PurchasingDepartmentManager"});

            var financeDepartmentManager = new AppUser
            {
                UserName = "FinanceDepartmentManager"
            };

            await userManager.CreateAsync(financeDepartmentManager, "Pa$$w0rd");
            await userManager.AddToRolesAsync(financeDepartmentManager, new[] {"FinanceDepartmentManager"});

            var hrDepartmentManager = new AppUser
            {
                UserName = "HRDepartmentManager"
            };

            await userManager.CreateAsync(hrDepartmentManager, "Pa$$w0rd");
            await userManager.AddToRolesAsync(hrDepartmentManager, new[] {"HRDepartmentManager"});

            var factoryManagementDepartmentManager = new AppUser
            {
                UserName = "FactoryManagementDepartmentManager"
            };

            await userManager.CreateAsync(factoryManagementDepartmentManager, "Pa$$w0rd");
            await userManager.AddToRolesAsync(factoryManagementDepartmentManager, new[] {"FactoryManagementDepartmentManager"});
        }    
    }
}