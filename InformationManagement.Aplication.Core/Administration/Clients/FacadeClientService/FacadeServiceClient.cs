using InformationManagement.Aplication.Core.Administration.Clients.Services;
using InformationManagement.Aplication.Dto.Administration.Clients;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace InformationManagement.Aplication.Core.Administration.Clients.FacadeClientService
{
    public class FacadeServiceClient : IFacadeServiceClient
    {
        private readonly IClientService _clientService;
        public FacadeServiceClient(IClientService clientService)
        {
            _clientService = clientService;
        }
        public async Task<ClientDto> ClientManagementDelete(ClientDto requestDto)
        {
            var result = await _clientService.DeleteClient(requestDto).ConfigureAwait(false);
            return new ClientDto
            {
                StatusCode = result ? HttpStatusCode.OK : HttpStatusCode.Unauthorized,
                StatusDescription = result ? "Ok" : "Error"
            };
        }

        public Task<ClientDto> ClientManagementGet(ClientDto requestDto)
        {
            return _clientService.SearchByIdClient(requestDto);
        }

        public Task<IEnumerable<ClientDto>> ClientManagementGetAll()
        {
            return _clientService.GetAllClientDto();
        }

        public async Task<ClientDto> ClientManagementInsert(ClientDto requestDto)
        {
            var result = await _clientService.AddClient(requestDto).ConfigureAwait(false);
            return new ClientDto
            {
                StatusCode = result != default ? HttpStatusCode.OK : HttpStatusCode.Unauthorized,
                StatusDescription = result != default ? "Ok" : "Error",
            };
        }

        public async Task<ClientDto> ClientManagementUpdate(ClientDto requestDto)
        {
            var result = await _clientService.UpdateClient(requestDto).ConfigureAwait(false);
            return new ClientDto
            {
                StatusCode = result ? HttpStatusCode.OK : HttpStatusCode.Unauthorized,
                StatusDescription = result ? "Ok" : "Error"
            };
        }
    }
}
