using InformationManagement.Aplication.Dto.Administration.Documents;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InformationManagement.Aplication.Core.Administration.Documents.FacadeDocumentService
{
    public class FacadeServiceDocument : IFacadeServiceDocument
    {
        public Task<DocumentResponseDto> DocumentManagementDelete(DocumentDto requestDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<DocumentDto> DocumentManagementGet(DocumentDto requestDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<DocumentDto>> DocumentManagementGetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<DocumentResponseDto> DocumentManagementInsert(DocumentDto requestDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<DocumentResponseDto> DocumentManagementUpdate(DocumentDto requestDto)
        {
            throw new System.NotImplementedException();
        }
    }
}
