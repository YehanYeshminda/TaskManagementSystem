using API.Dtos;
using API.Entities;
using API.Interfaces;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
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
        }
    }
}