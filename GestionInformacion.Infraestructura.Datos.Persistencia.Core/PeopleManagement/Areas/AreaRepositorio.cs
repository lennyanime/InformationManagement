using InformationManagement.Dominio.Core.Administration.Areas;
using InformationManagement.Dominio.Core.Areas;
using GestionInformacion.Infraestructura.Datos.Persistencia.Core.Base;

namespace GestionInformacion.Infraestructura.Datos.Persistencia.Core.PeopleManagement.Areas
{
    internal class AreaRepositorio : RepositorioBase<AreaEntity>, IAreaRepositorio
    {
        public AreaRepositorio(IContextDB unitOfWork) : base(unitOfWork) { }
    }
}
