using InformationManagement.Aplication.Core.Administration.Documents.FacadeDocumentService;
using InformationManagement.Aplication.Core.Administration.Documents.Services;
using InformationManagement.Aplication.Dto.Administration.Documents;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InformationManagement.WebApi.Controllers.ControllerFacadeDocument
{
    [ApiController]
    [Route("[controller]")]
    public class FacadeDocumentController : ControllerBase
    {
        private readonly ILogger<FacadeDocumentController> _logger;
        private readonly IFacadeServiceDocument _facadeDocumentService;

        public FacadeDocumentController(ILogger<FacadeDocumentController> logger , IFacadeServiceDocument documentService)
        {
            _facadeDocumentService = documentService;
        }

        [HttpPost(nameof(AddDocument))]
        public async Task<DocumentResponseDto> AddDocument(DocumentDto documentDto) =>
            await _facadeDocumentService.DocumentManagementInsert(documentDto).ConfigureAwait(false);

        [HttpPost(nameof(DeleteDocument))]
        public async Task<DocumentResponseDto> DeleteDocument(DocumentDto areaDto) =>
            await _facadeDocumentService.DocumentManagementDelete(areaDto).ConfigureAwait(false);

        [HttpPost(nameof(UpdateDocument))]
        public async Task<DocumentResponseDto> UpdateDocument(DocumentDto documentDto) =>
            await _facadeDocumentService.DocumentManagementUpdate(documentDto).ConfigureAwait(false);

        [HttpGet(nameof(GetDocument))]
        public async Task<DocumentDto> GetDocument(DocumentDto areaDto) =>
            await _facadeDocumentService.DocumentManagementGet(areaDto).ConfigureAwait(false);

        [HttpPost(nameof(GetAllDocument))]
        public async Task<IEnumerable<DocumentDto>> GetAllDocument() =>
            await _facadeDocumentService.DocumentManagementGetAll().ConfigureAwait(false);
    }
}
