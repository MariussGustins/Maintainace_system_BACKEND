using AutoMapper;
using Maintainace_system_BACKEND.DTOs;
using Maintainace_system_BACKEND.Models;

namespace Maintainace_system_BACKEND.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Kartē darbinieku modeļus uz DTO un otrādi
        CreateMap<Employee, EmployeeDto>().ReverseMap();
        CreateMap<EmployeeIdent, EmployeeIdentDto>().ReverseMap();
        
        // Kartē failu modeļus uz DTO un otrādi
        CreateMap<Files, FilesDto>().ReverseMap();
        
        // Kartē projektu modeļus uz DTO un otrādi
        CreateMap<Projects, ProjectsDto>().ReverseMap();
        
        // Kartē darbinieku lomu modeļus uz DTO un otrādi
        CreateMap<EmployeeRoles, EmployeeRolesDto>().ReverseMap();
        
        // Kartē papildu darbinieku modeļus uz DTO un otrādi
        CreateMap<EmployeeP, EmployeePDto>().ReverseMap();
    }
}
