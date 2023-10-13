using AutoMapper;
using MapApplication.Data.Models;
using MapApplication.Data.Models.DTOs.Incoming;
using MapApplication.Data.Models.DTOs.Outcoming;

namespace MapApplication.Data.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile() 
        {
            CreateMap<StudentCreationDto, Students>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => Guid.NewGuid())
                    )
                .ForMember(
                    dest => dest.FrstName,
                    opt => opt.MapFrom(src => $"{src.firstName}")
                    )
                .ForMember(
                    dest => dest.LastName,
                    opt => opt.MapFrom(src => $"{src.lastName}")
                    )
                .ForMember(
                    dest => dest.StudentNumber,
                    opt => opt.MapFrom(src => src.StudentNumber)
                    );

            CreateMap<Students, StudentDto>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => Guid.NewGuid())
                    )
                .ForMember(
                    dest => dest.FullName,
                    opt => opt.MapFrom(src=> $"{src.FrstName} {src.LastName}"))
                .ForMember(
                    dest => dest.StudentNumber,
                    opt => opt.MapFrom(src => src.StudentNumber)
                    );
        }
    }
}
