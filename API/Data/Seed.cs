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

            var member = new AppUser
            {
                UserName = "Member"
            };

            await userManager.CreateAsync(member, "Pa$$w0rd");
            await userManager.AddToRolesAsync(member, new[] { "Member" });

            var wordshopSupervisor = new AppUser
            {
                UserName = "WorkshopUnitSupervisor"
            };

            await userManager.CreateAsync(wordshopSupervisor, "Pa$$w0rd");
            await userManager.AddToRolesAsync(wordshopSupervisor, new[] { "WorkshopAndUnitSupervisor" });

            var admin = new AppUser
            {
                UserName = "Admin"
            };

            await userManager.CreateAsync(admin, "Pa$$w0rd");
            await userManager.AddToRolesAsync(admin, new[] { "Admin" });

            var departmentSupervisor = new AppUser
            {
                UserName = "DepartmentSupervisor"
            };

            await userManager.CreateAsync(departmentSupervisor, "Pa$$w0rd");
            await userManager.AddToRolesAsync(departmentSupervisor, new[] { "DepartmentSupervisor" });

            var engineeringDepartmentManager = new AppUser
            {
                UserName = "EngineeringDepartmentManager"
            };

            await userManager.CreateAsync(engineeringDepartmentManager, "Pa$$w0rd");
            await userManager.AddToRolesAsync(engineeringDepartmentManager, new[] { "EngineeringDepartmentManager" });

            var salesMarketingDepartmentManager = new AppUser
            {
                UserName = "SalesMarketingDepartmentManager"
            };

            await userManager.CreateAsync(salesMarketingDepartmentManager, "Pa$$w0rd");
            await userManager.AddToRolesAsync(salesMarketingDepartmentManager, new[] { "SalesMarketingDepartmentManager" });

            var purchasingDepartmentManager = new AppUser
            {
                UserName = "PurchasingDepartmentManager"
            };

            await userManager.CreateAsync(purchasingDepartmentManager, "Pa$$w0rd");
            await userManager.AddToRolesAsync(purchasingDepartmentManager, new[] { "PurchasingDepartmentManager" });

            var financeDepartmentManager = new AppUser
            {
                UserName = "FinanceDepartmentManager"
            };

            await userManager.CreateAsync(financeDepartmentManager, "Pa$$w0rd");
            await userManager.AddToRolesAsync(financeDepartmentManager, new[] { "FinanceDepartmentManager" });

            var hRDepartmentManager = new AppUser
            {
                UserName = "HRDepartmentManager"
            };

            await userManager.CreateAsync(hRDepartmentManager, "Pa$$w0rd");
            await userManager.AddToRolesAsync(hRDepartmentManager, new[] { "HRDepartmentManager" });

            var factoryManagementDepartmentManager = new AppUser
            {
                UserName = "FactoryManagementDepartmentManager"
            };

            await userManager.CreateAsync(factoryManagementDepartmentManager, "Pa$$w0rd");
            await userManager.AddToRolesAsync(factoryManagementDepartmentManager, new[] { "FactoryManagementDepartmentManager" });
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
                        Department = new Department()
                        {
                            Name = "Department 2",
                            Description = "this is department description",
                            DepartmentNo = "123",
                            PhoneNumber = "123456",
                            Email = "test@gmail.com",
                            CreatedAt = DateTime.Now,
                        }
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
                
                if (!context.Materials.Any())
                {
                    context.Materials.AddRange(new Materials()
                    {
                        Name = "Material 1",
                        Code = "121212",
                        Description = "this is description material",
                        CreatedAt = DateTime.Now,
                        Price = 100,
                        ReOrderLevel = 20,
                        UOM = "this is the uom",
                        MaterialType = new MaterialType()
                        {
                            Name = "Material 1",
                            Code = "121212",
                            Description = "this is description material",
                            CreatedAt = DateTime.Now,
                        }
                    });

                    context.Materials.AddRange(new Materials()
                    {
                        Name = "Material 2",
                        Code = "121212",
                        Description = "this is description material",
                        CreatedAt = DateTime.Now,
                        Price = 100,
                        ReOrderLevel = 20,
                        UOM = "this is the uom",
                        MaterialType = new MaterialType()
                        {
                            Name = "Material 2",
                            Code = "121212",
                            Description = "this is description material",
                            CreatedAt = DateTime.Now,
                        }
                    });

                    context.Materials.AddRange(new Materials()
                    {
                        Name = "Material 3",
                        Code = "131313",
                        Description = "this is description material",
                        CreatedAt = DateTime.Now,
                        Price = 100,
                        ReOrderLevel = 30,
                        UOM = "this is the uom",
                        MaterialType = new MaterialType()
                        {
                            Name = "Material 3",
                            Code = "131212",
                            Description = "this is description material",
                            CreatedAt = DateTime.Now,
                        }
                    });

                    await context.SaveChangesAsync();
                }


                if (!context.Grns.Any())
                {
                    var appUser = await context.AppUsers.FindAsync(1);
                    context.Grns.AddRange(new Grn()
                    {
                        GrnNo = "Number 1",
                        AppUser = appUser,
                        GrnDate = DateTime.Today,
                        CreatedAt = DateTime.Now,
                    });

                    await context.SaveChangesAsync();
                }
            }
        }
    }
}