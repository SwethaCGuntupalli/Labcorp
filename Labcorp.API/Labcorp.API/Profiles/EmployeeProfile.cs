using AutoMapper;
using Labcorp.API.Dtos;
using Labcorp.API.Models;

namespace Labcorp.API.Profiles;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<Employee, EmployeeDto>()
            .ForMember(dest=> dest.Type, opt=> opt.MapFrom(src=> src.GetType().Name));
    }
}
