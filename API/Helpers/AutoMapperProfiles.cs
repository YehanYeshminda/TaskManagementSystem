using API.Dtos;
using API.Entities;
using API.Extensions;
using API.Interfaces;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            var randomNum = GetRandomNumber.GetRandomZeroOne();

            CreateMap<RegisterDto, AppUser>();
            CreateMap<Unit, UnitDto>();
            CreateMap<UserTasks, TaskDto>().ForMember(s => s.AppUserName, opt => opt.MapFrom(s => s.AppUser.UserName));
            CreateMap<TaskUpdateDto, UserTasks>();
            CreateMap<InventoryDto, Inventory>();
            CreateMap<UpdateTaskMaterialDto, TaskMaterial>();
            CreateMap<TaskEmployee, EmployeePerformenceReportDto>().
                ForMember(s => s.AppUserName, opt => opt.MapFrom(s => s.AppUser.UserName)).
                ForMember(s => s.AppUserRole, opt => opt.MapFrom(s => s.AppUser.UserRoles.Select(s => s.Role.Name))).
                ForMember(s => s.DailyTarget, opt => opt.MapFrom(s => s.AppUser.EmployeeKpis.Select(s => s.DailyTarget))).
                ForMember(s => s.WeeklyTarget, opt => opt.MapFrom(s => s.AppUser.EmployeeKpis.Select(s => s.WeeklyTarget))).
                ForMember(s => s.MonthlyTarget, opt => opt.MapFrom(s => s.AppUser.EmployeeKpis.Select(s => s.MonthlyTarget))).
                ForMember(s => s.DepartmentName, opt => opt.MapFrom(s => s.AppUser.Departments.Name));

            CreateMap<Inventory, InventoryViewReportDto>()
                .ForMember(s => s.MaterialName, opt => opt.MapFrom(s => s.Materials.Name))
                .ForMember(s => s.MaterialCode, opt => opt.MapFrom(s => s.Materials.Code))
                .ForMember(s => s.ReOrderLevel, opt => opt.MapFrom(s => s.Materials.ReOrderLevel))
                .ForMember(s => s.GrnDate, opt => opt.MapFrom(s => s.Grn.GrnDate));

            CreateMap<Product, IncomeSummaryReportDto>()
                .ForMember(s => s.ProductName, opt => opt.MapFrom(s => s.Name))
                .ForMember(s => s.ProductCost, opt => opt.MapFrom(s => s.CostPrice))
                .ForMember(s => s.SoldPrice, opt => opt.MapFrom(s => s.SalePrice))
                .ForMember(s => s.SoldQty, opt => opt.MapFrom(s => s.UserTasks.Select(s => s.Qty)))
                .ForMember(s => s.Profit, opt => opt.MapFrom(s => s.CostPrice * s.UserTasks.Select(s => s.Qty).ToList()[randomNum]));

            CreateMap<Product, ProductIncomeDtoReport>()
                .ForMember(s => s.ProductName, opt => opt.MapFrom(s => s.Name))
                .ForMember(s => s.ProductDescription, opt => opt.MapFrom(s => s.Description))
                .ForMember(s => s.Qty, opt => opt.MapFrom(s => s.UserTasks.Select(s => s.Qty)))
                .ForMember(s => s.SingleProfit, opt => opt.MapFrom(s => s.UserTasks.Select(s => s.Qty).ToList()[0]))
                .ForMember(s => s.StartDate, opt => opt.MapFrom(s => s.UserTasks.Select(s => s.StartDate).ToList()[0]))
                .ForMember(s => s.EndDate, opt => opt.MapFrom(s => s.UserTasks.Select(s => s.EndDate).ToList()[0]));

            CreateMap<TaskEmployee, EmployeeSummaryDto>()
                .ForMember(s => s.EmployeeId, opt => opt.MapFrom(s => s.AppUser.Id))
                .ForMember(s => s.EmployeeName, opt => opt.MapFrom(s => s.AppUser.UserName))
                .ForMember(s => s.EmployeeRole, opt => opt.MapFrom(s => s.AppUser.UserRoles.Select(s => s.Role.Name)))
                .ForMember(s => s.EmployeeDob, opt => opt.MapFrom(s => s.AppUser.DateOfBirth.CalculateAge()))
                .ForMember(s => s.EmployeeNIC, opt => opt.MapFrom(s => s.AppUser.NIC))
                .ForMember(s => s.DepartmentName, opt => opt.MapFrom(s => s.AppUser.Departments.Name))
                .ForMember(s => s.LastPositions, opt => opt.MapFrom(s => s.AppUser.UserRoles.Select(s => s.Role.Name)));

            CreateMap<Product, ProductDto>()
                .ForMember(s => s.NumberOfSales, opt => opt.MapFrom(p => p.UserTasks.Sum(a => a.Qty)));

            CreateMap<WorkShop, WorkshopProductionDto>()
                .ForMember(s => s.WorkShopName, opt => opt.MapFrom(p => p.Name))
                .ForMember(s => s.WorkShopDescription, opt => opt.MapFrom(p => p.Description))
                .ForMember(s => s.NumberOfProducts, opt => opt.MapFrom(p => p.UserTasks.Sum(a => a.Qty)));
        }
    }
}