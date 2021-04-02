using AutoMapper;
using InformationManagement.Aplication.Dto.Administration.Employees;
using InformationManagement.Dominio.Core.Administracion.Personas;

namespace InformationManagement.Aplication.Core.Administration.Employees.Mapping
{
    public class EmployeeProfile: Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeEntity, EmployeeDto>().ReverseMap();
            CreateMap<EmployeeEntity, EmployeeRequestDto>().ReverseMap();
            CreateMap<EmployeeEntity, EmployeeResponseDto>().ReverseMap();
        }
    }
      
}
