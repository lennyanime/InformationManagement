using InformationManagement.Dominio.Core.Administracion.Personas;
using InformationManagement.Dominio.Core.Administration.Empleado;
using GestionInformacion.Infraestructura.Datos.Persistencia.Core.Base;

namespace GestionInformacion.Infraestructura.Datos.Persistencia.Core.PeopleManagement.Employees
{
    internal class EmployeeRepositorio : RepositorioBase<EmployeeEntity>, IEmployeeRepositorio
    {
        public EmployeeRepositorio(IContextDB unitOfWork) : base(unitOfWork) { }
    }
}
