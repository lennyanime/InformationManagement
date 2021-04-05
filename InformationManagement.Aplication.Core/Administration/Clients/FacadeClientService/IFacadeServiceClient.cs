using InformationManagement.Aplication.Dto.Administration.Clients;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InformationManagement.Aplication.Core.Administration.Clients.FacadeClientService
{
    public interface IFacadeServiceClient
    {
        public Task<ClientDto> ClientManagementGet(ClientDto requestDto);
        public Task<ClientDto> ClientManagementInsert(ClientDto requestDto);
        public Task<ClientDto> ClientManagementDelete(ClientDto requestDto);
        public Task<ClientDto> ClientManagementUpdate(ClientDto requestDto);
        public Task<IEnumerable<ClientDto>> ClientManagementGetAll();
    }
}
