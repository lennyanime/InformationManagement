using AutoMapper;
using InformationManagement.Dominio.Core.Areas;
using InformationManagement.Aplication.Dto.Administration.Areas;

namespace InformationManagement.Aplication.Core.Administration.Areas.Mapping
{
    public class AreaProfile : Profile
    {
        public AreaProfile()
        {
            CreateMap<AreaEntity, AreaDto>().ReverseMap();
            CreateMap<AreaEntity, AreaRequestDto>().ReverseMap();
            CreateMap<AreaEntity, AreaResponseDto>().ReverseMap();
        }
    }
}
