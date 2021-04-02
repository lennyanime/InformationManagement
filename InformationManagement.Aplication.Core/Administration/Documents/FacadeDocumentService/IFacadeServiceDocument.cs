using InformationManagement.Aplication.Dto.Administration.Documents;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InformationManagement.Aplication.Core.Administration.Documents.FacadeDocumentService
{
    public interface IFacadeServiceDocument
    {
        public Task<DocumentDto> DocumentManagementGet(DocumentDto requestDto);
        public Task<DocumentResponseDto> DocumentManagementInsert(DocumentDto requestDto);
        public Task<DocumentResponseDto> DocumentManagementDelete(DocumentDto requestDto);
        public Task<DocumentResponseDto> DocumentManagementUpdate(DocumentDto requestDto);
        public Task<IEnumerable<DocumentDto>> DocumentManagementGetAll();
    }
}
