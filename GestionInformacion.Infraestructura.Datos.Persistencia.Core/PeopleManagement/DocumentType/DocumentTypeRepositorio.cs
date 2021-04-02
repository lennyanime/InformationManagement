using InformationManagement.Dominio.Core.Administracion.Documento;
using InformationManagement.Dominio.Core.Administration.Document;
using GestionInformacion.Infraestructura.Datos.Persistencia.Core.Base;

namespace GestionInformacion.Infraestructura.Datos.Persistencia.Core.PeopleManagement.DocumentType
{
    internal class DocumentTypeRepositorio : RepositorioBase<DocumentTypeEntity>, IDocumentTypeRepositorio
    {
        public DocumentTypeRepositorio(IContextDB unitOfWork) : base(unitOfWork) { }
    }
}
