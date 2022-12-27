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
        }
    }
}