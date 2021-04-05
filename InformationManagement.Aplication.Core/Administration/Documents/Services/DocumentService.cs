using AutoMapper;
using InformationManagement.Dominio.Core.Administration.Document;
using InformationManagement.Aplication.Dto.Administration.Areas;
using InformationManagement.Aplication.Dto.Administration.Documents;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InformationManagement.Dominio.Core.Administracion.Documento;
using System.Linq;

namespace InformationManagement.Aplication.Core.Administration.Documents.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IMapper _mapper;
        private readonly IDocumentTypeRepositorio _documentRepositorio;
        public DocumentService(IMapper mapper , IDocumentTypeRepositorio documentRepositorio)
        {
            _mapper = mapper;
            _documentRepositorio = documentRepositorio;
        }
        public async Task<DocumentDto> AddDocument(DocumentDto request)
        {
            ValidationFields(request);
            var response = await _documentRepositorio.Insert(_mapper.Map<DocumentTypeEntity>(request)).ConfigureAwait(false);
            return _mapper.Map<DocumentDto>(response);
        }

        public Task<bool> DeleteDocument(DocumentDto request)
        {
            ValidationFields(request);
            var deleteDocument = _documentRepositorio
                .SearchMatching<DocumentTypeEntity>(e => e.TypeIdentificationId == request.TypeIdentificationId).FirstOrDefault();
            if (deleteDocument == default || deleteDocument == null)
                throw new DeleteDocumentDenied();
            var response = _documentRepositorio.Delete(_mapper.Map<DocumentTypeEntity>(deleteDocument));
            return Task.FromResult(response);
        }

        public Task<IEnumerable<DocumentDto>> GetAllDocuments()
        {
            var document = _documentRepositorio
                .GetAll<DocumentTypeEntity>();
            return Task.FromResult(_mapper.Map<IEnumerable<DocumentDto>>(document));
        }

        public Task<DocumentDto> SearchDocumentById(DocumentDto request)
        {
            ValidationFields(request);
            var documentIdExist = _documentRepositorio
                 .SearchMatching<DocumentTypeEntity>(id => id.TypeIdentificationId == request.TypeIdentificationId).FirstOrDefault();
            return Task.FromResult(_mapper.Map<DocumentDto>(documentIdExist));
        }

        public Task<bool> UpdateDocument(DocumentDto request)
        {
            ValidationFields(request);
            var updateDocument = _documentRepositorio
                .SearchMatching<DocumentTypeEntity>(u => u.TypeIdentificationId == request.TypeIdentificationId).FirstOrDefault();
            var response = _documentRepositorio.Update(_mapper.Map<DocumentTypeEntity>(updateDocument));
            return Task.FromResult(response);
        }

        private static void ValidationFields(DocumentDto request)
        {
            if (request == null)
                throw new ArgumentNullException();
        }


    }
}
