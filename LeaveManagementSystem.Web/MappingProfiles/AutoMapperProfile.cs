using AutoMapper;
using LeaveManagementSystem.Web.Data;
using LeaveManagementSystem.Web.Models.LeaveTypes;

namespace LeaveManagementSystem.Web.MappingProfiles
{
    public class AutoMapperProfile:Profile
    {
       public AutoMapperProfile()
       {
            CreateMap<LeaveType, LeaveTypeReadOnlyVM>()
                .ForMember(
                dest => dest.Days,
                opt => opt.MapFrom(src => src.NumberOfDays)
                );

            CreateMap<LeaveTypeCreateVM, LeaveType>()
                .ForMember(
                dest=>dest.NumberOfDays,
                opt=>opt.MapFrom(src => src.Days)
                );

            CreateMap<LeaveTypeEditVM, LeaveType>()
                .ForMember(
                dest => dest.NumberOfDays,
                opt => opt.MapFrom(src => src.Days)
                ).ReverseMap();
       }
    }
}
