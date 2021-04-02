using GestionInformacion.Infraestructura.Datos.Persistencia.Core.PeopleManagement.Areas;
using GestionInformacion.Infraestructura.Datos.Persistencia.Core.PeopleManagement.Clients;
using GestionInformacion.Infraestructura.Datos.Persistencia.Core.PeopleManagement.DocumentType;
using GestionInformacion.Infraestructura.Datos.Persistencia.Core.PeopleManagement.Employees;
using GestionInformacion.Infraestructura.Datos.Persistencia.Core.PeopleManagement.Providers;
using InformationManagement.Dominio.Core.Administration.Areas;
using InformationManagement.Dominio.Core.Administration.Cliente;
using InformationManagement.Dominio.Core.Administration.Document;
using InformationManagement.Dominio.Core.Administration.Empleado;
using InformationManagement.Dominio.Core.Administration.Proveedor;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace GestionInformacion.Infraestructura.Datos.Persistencia.Core.Base.Configuration
{
    public static class RepositoryConfigurator
    {
        public static void ConfigureBaseRepository(this IServiceCollection services, DbSettings settings) 
        {
            services.TryAddTransient<IAreaRepositorio, AreaRepositorio>();
            services.TryAddTransient<IDocumentTypeRepositorio, DocumentTypeRepositorio>();
            services.TryAddTransient<IClientRepositorio, ClientRepositorio>();
            services.TryAddTransient<IEmployeeRepositorio, EmployeeRepositorio>();
            services.TryAddTransient<IProviderRepositorio, ProviderRepositorio>();

            services.ConfigureContext(settings);
        }
        public static void ConfigureContext(this IServiceCollection services, DbSettings settings)
        {
            services.Configure<DbSettings>(o => o.CopyFrom(settings));
            services.TryAddScoped<IContextDB, ContextDB>();
        }
    }
}
