using InformationManagement.Aplication.Dto.Administration.Providers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InformationManagement.Aplication.Core.Administration.Providers.Services
{
    public interface IProviderService
    {
        public Task<ProviderDto> AddProvider(ProviderDto request);

        public Task<ProviderDto> SearchByIdProvider(ProviderDto request);

        public Task<bool> DeleteProvider(ProviderDto request);

        public Task<bool> UpdateProvider(ProviderDto request);

        public Task<IEnumerable<ProviderDto>> GetAllProviderDto();
        public Task<string> ExportAll();
        public Task<IEnumerable<ProviderDto>> ImportAll();
    }
}
