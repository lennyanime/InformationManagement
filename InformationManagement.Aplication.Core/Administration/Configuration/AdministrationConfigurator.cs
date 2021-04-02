using GestionInformacion.Infraestructura.Datos.Persistencia.Core.Base.Configuration;
using InformationManagement.Aplication.Core.Administration.Areas;
using InformationManagement.Aplication.Core.Administration.Clients.Services;
using InformationManagement.Aplication.Core.Administration.Documents.Services;
using InformationManagement.Aplication.Core.Administration.Employees.Services;
using InformationManagement.Aplication.Core.Administration.Providers.Services;
using InformationManagement.Aplication.Core.Mapper.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace InformationManagement.Aplication.Core.Administration.Configuration
{
    public static class AdministrationConfigurator
    {
        public static void ConfigureAdministrationConfigurator(this IServiceCollection services, DbSettings settings) 
        {
            services.TryAddTransient<IAreaService, AreaService>();
            services.TryAddTransient<IDocumentService, DocumentService>();
            services.TryAddTransient<IClientService, ClientService>();
            services.TryAddTransient<IEmployeeService, EmployeeService>();
            services.TryAddTransient<IProviderService, ProviderService>();

            services.ConfigureMapper();
            services.ConfigureBaseRepository(settings);
        }
    }
}
