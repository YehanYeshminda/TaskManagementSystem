using System.Text;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace API.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIndentityServices(this IServiceCollection services, IConfiguration _config)
        {
            services.AddIdentityCore<AppUser>(options => 
            {
                options.Password.RequireNonAlphanumeric = false;
            })
            .AddRoles<AppRole>()
            .AddRoleManager<RoleManager<AppRole>>()
            .AddEntityFrameworkStores<DataContext>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["TokenKey"])), 
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });

            services.AddAuthorization(opt =>
            {
                opt.AddPolicy("RequiredDepartmentSupervisor", policy => policy.RequireRole("DepartmentSupervisor"));
                opt.AddPolicy("RequiredWorkshopAndUnitSupervisor", policy => policy.RequireRole("WorkshopAndUnitSupervisor"));
                opt.AddPolicy("RequiredSalesMarketingDepartmentManager", policy => policy.RequireRole("SalesMarketingDepartmentManager"));
                opt.AddPolicy("RequiredPurchasingFinanceManager", policy => policy.RequireRole("FinanceDepartmentManager", "PurchasingDepartmentManager"));
                opt.AddPolicy("RequiredHRDepartmentManager", policy => policy.RequireRole("HRDepartmentManager"));
                opt.AddPolicy("RequiredEngineeringDepartmentManager", policy => policy.RequireRole("EngineeringDepartmentManager"));
                opt.AddPolicy("RequiredFactoryManagementDepartmentManager", policy => policy.RequireRole("FactoryManagementDepartmentManager"));
            });

            return services;
        }
    }
}