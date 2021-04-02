using InformationManagement.Aplication.Dto.Administration.Areas;
using InformationManagement.Aplication.Dto.Administration.Documents;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InformationManagement.Aplication.Core.Administration.Documents.Services
{
    public interface IDocumentService
    {
        public Task<DocumentDto> AddDocument(DocumentDto request);

        public Task<DocumentDto> SearchDocumentById(DocumentDto request);
        public Task<bool> DeleteDocument(DocumentDto request);

        public Task<bool> UpdateDocument(DocumentDto request);

        public Task<IEnumerable<DocumentDto>> GetAllDocuments();
    }
}
