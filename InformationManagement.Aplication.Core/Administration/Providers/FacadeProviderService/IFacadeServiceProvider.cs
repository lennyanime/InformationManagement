using InformationManagement.Aplication.Dto.Administration.Providers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InformationManagement.Aplication.Core.Administration.Providers.FacadeService
{
    public interface IFacadeServiceProvider
    {
        public Task<ProviderDto> ProviderManagementGet(ProviderDto requestDto);
        public Task<ProviderDto> ProviderManagementInsert(ProviderDto requestDto);
        public Task<ProviderDto> ProviderManagementDelete(ProviderDto requestDto);
        public Task<ProviderDto> ProviderManagementUpdate(ProviderDto requestDto);
        public Task<IEnumerable<ProviderDto>> ProviderManagementGetAll();

        public Task<string> ProviderManagementExportAll();
        public Task<IEnumerable<ProviderDto>> ProviderManagementImportAll();

    }
}
