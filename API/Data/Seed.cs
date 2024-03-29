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


        public static async void SeedInformation(ApplicationBuilder applicationBuilder, RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
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
                        },
                    });

                    await context.SaveChangesAsync();
                }

                if (!context.WorkShops.Any())
                {
                    var department = await context.Departments.FindAsync(1);

                    context.WorkShops.AddRange(new WorkShop()
                    {
                        Name = "WorkShop 1",
                        Description = "this is a new work shop",
                        Telephone = "123",
                        Email = "test@gmail.com",
                        CreatedAt = DateTime.Now,
                        Department = department,
                    });

                    context.WorkShops.AddRange(new WorkShop()
                    {
                        Name = "WorkShop 2",
                        Description = "this is a new work shop",
                        Telephone = "123",
                        Email = "test@gmail.com",
                        CreatedAt = DateTime.Now,
                        Department = department,
                    });

                    context.WorkShops.AddRange(new WorkShop()
                    {
                        Name = "WorkShop 3",
                        Description = "this is a new work shop",
                        Telephone = "123",
                        Email = "test@gmail.com",
                        CreatedAt = DateTime.Now,
                        Department = department,
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
                        Qty = 10,
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
                        Qty = 10,
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
                        Qty = 10,
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

                if (!context.Inventories.Any())
                {
                    var material = await context.Materials.FindAsync(1);
                    var grn = await context.Grns.FindAsync(1);

                    context.Inventories.AddRange(new Inventory()
                    {
                        Qty = 10,
                        AvailableQty = 10,
                        UnitCost = 100,
                        CreatedAt = DateTime.Now,
                        Materials = material,
                        Grn = grn,
                    });

                    context.Inventories.AddRange(new Inventory()
                    {
                        Qty = 10,
                        AvailableQty = 10,
                        UnitCost = 100,
                        CreatedAt = DateTime.Now,
                        Materials = material,
                        Grn = grn,
                    });

                    context.Inventories.AddRange(new Inventory()
                    {
                        Qty = 10,
                        AvailableQty = 10,
                        UnitCost = 100,
                        CreatedAt = DateTime.Now,
                        Materials = material,
                        Grn = grn,
                    });

                    context.Inventories.AddRange(new Inventory()
                    {
                        Qty = 10,
                        AvailableQty = 10,
                        UnitCost = 100,
                        CreatedAt = DateTime.Now,
                        Materials = material,
                        Grn = grn,
                    });

                    context.Inventories.AddRange(new Inventory()
                    {
                        Qty = 10,
                        AvailableQty = 10,
                        UnitCost = 100,
                        CreatedAt = DateTime.Now,
                        Materials = material,
                        Grn = grn,
                    });

                    context.Inventories.AddRange(new Inventory()
                    {
                        Qty = 10,
                        AvailableQty = 10,
                        UnitCost = 100,
                        CreatedAt = DateTime.Now,
                        Materials = material,
                        Grn = grn,
                    });

                    await context.SaveChangesAsync();
                }

                if (!context.UserTasks.Any())
                {
                    var department = await context.Departments.FindAsync(1);
                    var workShop = await context.WorkShops.FindAsync(1);
                    var appUser = await context.AppUsers.FindAsync(1);
                    var unit = await context.Unit.FindAsync(1);
                    var product = await context.Product.FindAsync(1);

                    context.UserTasks.AddRange(new UserTasks()
                    {
                        Name = "Task 1",
                        Description = "this is the description",
                        CustomerDetails = "this is the customer details",
                        Qty = 1,
                        Status = "todo",
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now,
                        CreatedAt = DateTime.Now,
                        Department = department,
                        WorkShop = workShop,
                        AppUser = appUser,
                        Unit = unit,
                        Product = product,
                    });

                    context.UserTasks.AddRange(new UserTasks()
                    {
                        Name = "Task 2",
                        Description = "this is the description",
                        CustomerDetails = "this is the customer details",
                        Qty = 100,
                        Status = "todo",
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now,
                        CreatedAt = DateTime.Now,
                        Department = department,
                        WorkShop = workShop,
                        AppUser = appUser,
                        Unit = unit,
                        Product = product,
                    });

                    context.UserTasks.AddRange(new UserTasks()
                    {
                        Name = "Task 3",
                        Description = "this is the description",
                        CustomerDetails = "this is the customer details",
                        Qty = 100,
                        Status = "todo",
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now,
                        CreatedAt = DateTime.Now,
                        Department = department,
                        WorkShop = workShop,
                        AppUser = appUser,
                        Unit = unit,
                        Product = product,
                    });

                    context.UserTasks.AddRange(new UserTasks()
                    {
                        Name = "Task 4",
                        Description = "this is the description",
                        CustomerDetails = "this is the customer details",
                        Qty = 100,
                        Status = "todo",
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now,
                        CreatedAt = DateTime.Now,
                        Department = department,
                        WorkShop = workShop,
                        AppUser = appUser,
                        Unit = unit,
                        Product = product,
                    });

                    await context.SaveChangesAsync();
                }

                if (!context.TaskEmployees.Any())
                {
                    var appuser = await context.AppUsers.FindAsync(1);
                    var appuser2 = await context.AppUsers.FindAsync(3);
                    var userTask = await context.UserTasks.FindAsync(1);

                    context.TaskEmployees.AddRange(new TaskEmployee()
                    {
                        AppUser = appuser,
                        UserTasks = userTask,
                        CreatedAt = DateTime.Now,
                    });

                    context.TaskEmployees.AddRange(new TaskEmployee()
                    {
                        AppUser = appuser,
                        UserTasks = userTask,
                        CreatedAt = DateTime.Now,
                    });

                    context.TaskEmployees.AddRange(new TaskEmployee()
                    {
                        AppUser = appuser,
                        UserTasks = userTask,
                        CreatedAt = DateTime.Now,
                    });

                    context.TaskEmployees.AddRange(new TaskEmployee()
                    {
                        AppUser = appuser,
                        UserTasks = userTask,
                        CreatedAt = DateTime.Now,
                    });

                    context.TaskEmployees.AddRange(new TaskEmployee()
                    {
                        AppUser = appuser,
                        UserTasks = userTask,
                        CreatedAt = DateTime.Now,
                    });

                    context.TaskEmployees.AddRange(new TaskEmployee()
                    {
                        AppUser = appuser2,
                        UserTasks = userTask,
                        CreatedAt = DateTime.Now,
                    });

                    await context.SaveChangesAsync();
                }

                if (!context.EmployeeKpis.Any())
                {
                    var user = await context.AppUsers.FindAsync(1);
                    var product = await context.Product.FindAsync(1);

                    context.EmployeeKpis.AddRange(new EmployeeKpi()
                    {
                        AppUser = user,
                        Product = product,
                        DailyTarget = 1000,
                        MonthlyTarget = 10000,
                        WeeklyTarget = 100000
                    });

                    await context.SaveChangesAsync();
                }
            }
        }
    }
}