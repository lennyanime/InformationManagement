using AutoMapper;
using InformationManagement.Aplication.Dto.Administration.Documents;
using InformationManagement.Dominio.Core.Administracion.Documento;

namespace InformationManagement.Aplication.Core.Administration.Documents
{
    public class DocumentProfile:Profile
    {
        public DocumentProfile()
        {
            CreateMap<DocumentTypeEntity, DocumentDto>().ReverseMap();
            CreateMap<DocumentTypeEntity, DocumentRequestDto>().ReverseMap();
            CreateMap<DocumentTypeEntity, DocumentResponseDto>().ReverseMap();
        }
    }
}
