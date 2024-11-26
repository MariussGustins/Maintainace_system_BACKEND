using AutoMapper;
using Maintainace_system_BACKEND.DTOs;
using Maintainace_system_BACKEND.Models;

namespace Maintainace_system_BACKEND.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Employee, EmployeeDto>().ReverseMap();
        CreateMap<EmployeeIdent, EmployeeIdentDto>().ReverseMap();
        CreateMap<Files, FilesDto>().ReverseMap();
        CreateMap<Projects, ProjectsDto>().ReverseMap();
        CreateMap<EmployeeRoles, EmployeeRolesDto>().ReverseMap();
        CreateMap<EmployeeP, EmployeePDto>().ReverseMap();
    }
}