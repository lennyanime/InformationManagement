using InformationManagement.Dominio.Core.Administracion.Personas;
using InformationManagement.Dominio.Core.Administration.Proveedor;
using GestionInformacion.Infraestructura.Datos.Persistencia.Core.Base;

namespace GestionInformacion.Infraestructura.Datos.Persistencia.Core.PeopleManagement.Providers
{
    internal class ProviderRepositorio : RepositorioBase<ProviderEntity>, IProviderRepositorio
    {
        public ProviderRepositorio(IContextDB unitOfWork) : base(unitOfWork) { }
    }
}
