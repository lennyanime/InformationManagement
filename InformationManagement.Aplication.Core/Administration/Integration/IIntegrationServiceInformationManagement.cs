using InformationManagement.Aplication.Dto.DataTransfer_Object;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InformationManagement.Aplication.Core.Administration.Integration
{
    public interface IIntegrationServiceInformationManagement
    {
        Task<string> ExportJson<T>(string path, T request) where T : IEnumerable<DataTransferObject>;
        Task<T> ImportJson<T>(string path) where T : IEnumerable<DataTransferObject>;
    }
}
