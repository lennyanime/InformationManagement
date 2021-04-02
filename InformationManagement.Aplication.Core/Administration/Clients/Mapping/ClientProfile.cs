using AutoMapper;
using InformationManagement.Dominio.Core.Administration.Person;
using InformationManagement.Aplication.Dto.Administration.Clients;

namespace InformationManagement.Aplication.Core.Administration.Clients.Mapping
{
    public class ClientProfile:Profile
    {
        public ClientProfile()
        {
            CreateMap<ClientEntity, ClientDto>().ReverseMap();
            CreateMap<ClientEntity, ClientRequestDto>().ReverseMap();
            CreateMap<ClientEntity, ClientResponseDto>().ReverseMap();
        }
    }
}
