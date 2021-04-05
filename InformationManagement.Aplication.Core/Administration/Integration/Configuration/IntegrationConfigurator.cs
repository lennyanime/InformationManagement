using GestionInformacion.Infraestructura.Datos.Persistencia.Core.Base.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace InformationManagement.Aplication.Core.Administration.Integration.Configuration
{
    public static class IntegrationConfigurator
    {
        public static void ConfigureIntegrationService(this IServiceCollection services)
        {
            services.TryAddTransient<IIntegrationServiceInformationManagement, IntegrationServiceInformationManagement>();
        }
    }
}
