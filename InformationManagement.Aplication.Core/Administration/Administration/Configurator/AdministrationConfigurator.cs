using GestionInformacion.Infraestructura.Datos.Persistencia.Core.Base.Configuration;
using InformationManagement.Aplication.Core.Administration.Areas;
using InformationManagement.Aplication.Core.Administration.Clients.Services;
using InformationManagement.Aplication.Core.Administration.Documents.FacadeDocumentService;
using InformationManagement.Aplication.Core.Administration.Documents.Services;
using InformationManagement.Aplication.Core.Administration.Employees.FacadeEmployeeService;
using InformationManagement.Aplication.Core.Administration.Employees.Services;
using InformationManagement.Aplication.Core.Administration.FacadeAreaService;
using InformationManagement.Aplication.Core.Administration.Providers.Services;
using InformationManagement.Aplication.Core.Mapper.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace InformationManagement.Aplication.Core.Administration.Administration.Configurator
{
    public static class AdministrationConfigurator
    {
        public static void ConfigureAdministrationService(this IServiceCollection services , DbSettings settings) 
        {
            services.TryAddTransient<IFacadeServiceDocument, FacadeServiceDocument>();
            services.TryAddTransient<IFacadeServiceArea, FacadeServiceArea>();
            services.TryAddTransient<IFacadeServiceEmployee, FacadeServiceEmployee>();

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
