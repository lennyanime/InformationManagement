using AutoMapper;
using InformationManagement.Aplication.Dto.Administration.Clients;
using InformationManagement.Dominio.Core.Administration.Cliente;
using InformationManagement.Dominio.Core.Administration.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InformationManagement.Aplication.Core.Administration.Clients.Services
{
    public class ClientService : IClientService
    {
        private readonly IMapper _mapper;
        private readonly IClientRepositorio _clientRepo;

        public ClientService(IMapper mapper , IClientRepositorio clientRepo)
        {
            _mapper = mapper;
            _clientRepo = clientRepo;
        }
        public async Task<ClientDto> AddClient(ClientDto request)
        {
            ValidateDataNotNull(request);
            
            var clientGetAll = _clientRepo
              .GetAll<ClientEntity>();

            var idClientExist = clientGetAll.Where(c=>c.ClientId == request.ClientId);

            var nameClientExist = clientGetAll.Where(n => n.FirstName == request.FirstName && n.FirstLastName == request.FirstLastName
                                                   && n.SecondName == request.SecondName && n.SecondLastName == request.SecondLastName);

            //preguntar por el orden
            if (nameClientExist.Any())
                throw new NameClientAlreadyExist();

            if (request.TypeDocument.ToString().ToLower().Equals("Nit".ToLower()))
                throw new ClientHaveNotNit();

            if (idClientExist.Any())
                throw new IdClientAlreadyExist();

            if (request.DateOfBirth == null || request.SignUpDate == null || request.DateOfBirth == default || request.SignUpDate == default)
                throw new DateCreationNotExistForClient();

            var response = await _clientRepo.Insert(_mapper.Map<ClientEntity>(request)).ConfigureAwait(false);

            return _mapper.Map<ClientDto>(response);
        }

        public Task<bool> DeleteClient(ClientDto request)
        {
            ValidateDataNotNull(request);
            var deleteClient = _clientRepo
                .SearchMatching<ClientEntity>(c => c.ClientId == request.ClientId).FirstOrDefault();

            if (deleteClient == default || deleteClient == null)
                throw new DeleteClientDenied();

            var response = _clientRepo.Delete(_mapper.Map<ClientEntity>(deleteClient));
            return Task.FromResult(response);
        }

        public Task<IEnumerable<ClientDto>> GetAllClientDto()
        {
            var clientGetAll = _clientRepo
              .GetAll<ClientEntity>();
            return Task.FromResult(_mapper.Map<IEnumerable<ClientDto>>(clientGetAll));
        }

        public Task<ClientDto> SearchByIdClient(ClientDto request)
        {
            ValidateDataNotNull(request);
            var searchByIdClient = _clientRepo
               .SearchMatching<ClientEntity>(id => id.ClientId == request.ClientId).FirstOrDefault();
            return Task.FromResult(_mapper.Map<ClientDto>(searchByIdClient));
        }

        public Task<bool> UpdateClient(ClientDto request)
        {
            ValidateDataNotNull(request);
            var searchByIdClient = _clientRepo
                .SearchMatching<ClientEntity>(id => id.ClientId == request.ClientId).FirstOrDefault();
            var response = _clientRepo.Update(_mapper.Map<ClientEntity>(searchByIdClient));
            return Task.FromResult(true);
        }

        public static void ValidateDataNotNull(ClientDto request)
        {
            if (request == null)
                throw new ArgumentNullException();
        }
    }
}
