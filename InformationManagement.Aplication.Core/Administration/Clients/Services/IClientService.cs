using InformationManagement.Aplication.Dto.Administration.Clients;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InformationManagement.Aplication.Core.Administration.Clients.Services
{
    public interface IClientService
    {
        public Task<ClientDto> AddClient(ClientDto request);

        public Task<ClientDto> SearchByIdClient(ClientDto request);

        public Task<bool> DeleteClient(ClientDto request);

        public Task<bool> UpdateClient(ClientDto request);

        public Task<IEnumerable<ClientDto>> GetAllClientDto();
    }
}
