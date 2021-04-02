using AutoMapper;
using InformationManagement.Aplication.Dto.Administration.Providers;
using InformationManagement.Dominio.Core.Administracion.Personas;

namespace InformationManagement.Aplication.Core.Administration.Providers.Mapping
{
    public class ProviderProfile:Profile
    {
        public ProviderProfile()
        {
            CreateMap<ProviderEntity, ProviderDto>().ReverseMap();
            CreateMap<ProviderEntity, ProviderRequestDto>().ReverseMap();
            CreateMap<ProviderEntity, ProviderResponseDto>().ReverseMap();
        }
       
    }
}
