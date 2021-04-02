using InformationManagement.Dominio.Core.Base;
using System;

namespace GestionInformacion.Infraestructura.Datos.Persistencia.Core.Base
{
    public interface IContextDB: IUnitOfWork, IDisposable
    {
    }
}
