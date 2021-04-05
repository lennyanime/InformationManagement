using InformationManagement.Aplication.Core.Administration.Integration;
using InformationManagement.Aplication.Core.Administration.Integration.Configuration;
using InformationManagement.Aplication.Core.Administration.Integration.Exceptions;
using InformationManagement.Aplication.Dto.Administration;
using InformationManagement.Aplication.Dto.Administration.Clients;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Xunit.Categories;

namespace InformationManagement.Test.Core.Aplicacion.Administration.Core.Integration.IntegrationTestUnit
{
    public class IntegrationUnitTest
    {
        [Fact]
        [UnitTest]
        public async Task Patch_Throws_NotImplementedException()
        {
            var service = new ServiceCollection();

            service.ConfigureIntegrationService();
            var provider = service.BuildServiceProvider();
            var integracionPersonaService = provider.GetRequiredService<IIntegrationServiceInformationManagement>();

            var dtoCliente = new List<ClientDto>{ new ClientDto
                {
                   FirstName = "lenny",
                   FirstLastName = "trejos"
                } };

            await Assert.ThrowsAsync<IntegrationArgumentPathException>(async () => await integracionPersonaService.ExportJson("", dtoCliente).ConfigureAwait(false)).ConfigureAwait(false);
        }
        [Fact]
        [UnitTest]
        public async Task Export_Full()
        {
            var service = new ServiceCollection();

            service.ConfigureIntegrationService();
            var provider = service.BuildServiceProvider();
            var integracionPersonaService = provider.GetRequiredService<IIntegrationServiceInformationManagement>();

            var dtoCliente = new ClientDto
            {
                ClientId = Guid.Parse("64b383da-dbed-4d1a-bd70-be416be2f1b6"),
                FirstName = "Lenny",
                SecondName = "Alexander",
                FirstLastName = "Trejos",
                SecondLastName = "Bermúdez",
                TypeDocument = Type_Document.Nit,
            };
            var result = await integracionPersonaService.ExportJson("ExportCliente", new List<ClientDto> { dtoCliente }).ConfigureAwait(false);
            
            var dtoClienteList = new List<ClientDto>{ new ClientDto
            {
                ClientId = Guid.Parse("64b383da-dbed-4d1a-bd70-be416be2f1b6"),
                FirstName = "Lenny",
                SecondName = "Alexander",
                FirstLastName = "Trejos",
                SecondLastName = "Bermúdez",
                TypeDocument = Type_Document.Cedula,
            },
            new ClientDto
            {
                ClientId = Guid.Parse("64b383da-dbed-4d1a-bd70-be416be2f1b6"),
                FirstName = "Lenny",
                SecondName = "Alexander",
                FirstLastName = "Trejos",
                SecondLastName = "Bermúdez",
                TypeDocument = Type_Document.Pasaporte,
            }};
            var result2 = await integracionPersonaService.ExportJson("ExportListCliente", dtoClienteList).ConfigureAwait(false);

            Assert.NotNull(result);
            Assert.NotNull(result2);
        }
        [Fact]
        [UnitTest]
        public async Task Import_Full()
        {
            var service = new ServiceCollection();

            service.ConfigureIntegrationService();
            var provider = service.BuildServiceProvider();
            var integracionPersonaService = provider.GetRequiredService<IIntegrationServiceInformationManagement>();

            var result = await integracionPersonaService.ImportJson<IEnumerable<ClientDto>>("ExportCliente").ConfigureAwait(false);
            var result2 = await integracionPersonaService.ImportJson<IEnumerable<ClientDto>>("ExportListCliente").ConfigureAwait(false);

            Assert.NotNull(result);
            Assert.NotNull(result2);
        }
    }
}
