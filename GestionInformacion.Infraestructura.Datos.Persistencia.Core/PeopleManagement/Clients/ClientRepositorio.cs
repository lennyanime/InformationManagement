using InformationManagement.Dominio.Core.Administration.Cliente;
using GestionInformacion.Infraestructura.Datos.Persistencia.Core.Base;
using InformationManagement.Dominio.Core.Administration.Person;

namespace GestionInformacion.Infraestructura.Datos.Persistencia.Core.PeopleManagement.Clients
{
    internal class ClientRepositorio:RepositorioBase<ClientEntity>, IClientRepositorio
    {
        public ClientRepositorio(IContextDB unitOfWork) : base(unitOfWork) { }
    }
}
