using GestionInformacion.Infraestructura.Datos.Persistencia.Core.Base.Configuration;
using InformationManagement.Aplication.Core.Administration.Administration.Configurator;
using InformationManagement.Aplication.Core.Administration.Clients.Services;
using InformationManagement.Aplication.Dto.Administration;
using InformationManagement.Aplication.Dto.Administration.Clients;
using InformationManagement.Dominio.Core.Administration;
using InformationManagement.Dominio.Core.Administration.Cliente;
using InformationManagement.Dominio.Core.Administration.Person;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;
using Xunit.Categories;

namespace InformationManagement.Test.Core.Aplicacion.Administration.Core.Clients.UnitTestClients
{
    public class ClientsTest
    {
        [Fact]
        [UnitTest]

        public async Task Client_Can_Not_Have_Type_Identification_Nit() 
        {
            var clientRepoMock = new Mock<IClientRepositorio>();
           
            var service = new ServiceCollection();
            service.AddTransient(_ => clientRepoMock.Object);
            service.ConfigureAdministrationService(new DbSettings());
            var provider = service.BuildServiceProvider();
            var clientService = provider.GetRequiredService<IClientService>();

            var client = new ClientDto
            {
                ClientId = Guid.Parse("64b383da-dbed-4d1a-bd70-be416be2f1b6"),
                FirstName = "Lenny",
                SecondName = "Alexander",
                FirstLastName = "Trejos",
                SecondLastName = "Bermúdez",
                TypeDocument = Type_Document.Nit,
               
            };

            await Assert.ThrowsAsync<ClientHaveNotNit>(() => clientService.AddClient(client)).ConfigureAwait(false);
        }

        [Fact]
        [UnitTest]

        public async Task Client_With_The_Same_Id_Is_Not_Permitted()
        {
            var clientRepoMock = new Mock<IClientRepositorio>();

            var listEmployee = new List<ClientEntity>
            {
                new ClientEntity
                {
                    
                    ClientId = Guid.Parse("ee98a9db-1443-4491-b470-cca353138848"),
                  
                    FirstName = "Lenny",
                    SecondName = "Alexander",
                    FirstLastName = "Trejos",
                    SecondLastName = "Bermúez",
                    KindOfPerson = KindOfPerson.Natural,
                    DateOfBirth = DateTimeOffset.Parse("28-05-1992"),
                    SignUpDate = DateTimeOffset.Parse("12-02-2020"),
                    
                }
            };
            clientRepoMock
                .Setup(m => m.GetAll<ClientEntity>())
                .Returns(listEmployee);

            var service = new ServiceCollection();
            service.ConfigureAdministrationService(new DbSettings());
            service.AddTransient(_ => clientRepoMock.Object);
            var provider = service.BuildServiceProvider();
            var employeeService = provider.GetRequiredService<IClientService>();

            var client = new ClientDto
            {
                ClientId = Guid.Parse("ee98a9db-1443-4491-b470-cca353138848"),
                FirstName = "Lenny",
                SecondName = "Alexander",
                FirstLastName = "Trejos",
                SecondLastName = "Bermúdez",
                TypePerson = TypeOfPerson.Natural, 
                DateOfBirth = DateTimeOffset.Parse("28-05-1992"),
                SignUpDate = DateTimeOffset.Parse("12-02-2020"),
            };

            await Assert.ThrowsAsync<IdClientAlreadyExist>(() => employeeService.AddClient(client)).ConfigureAwait(false);
        }

        [Fact]
        [UnitTest]

        public async Task Name_Employeed_Already_Exist()
        {
            var clientRepoMock = new Mock<IClientRepositorio>();

            var listClient= new List<ClientEntity>
            {
                new ClientEntity
                {
                    ClientId = Guid.Parse("3dcf7212-0984-4f61-b2b3-8f1c12120fec"),
                    FirstName = "Lenny",
                    SecondName = "Alexander",
                    FirstLastName = "Trejos",
                    SecondLastName = "Bermúdez",
                    KindOfPerson = KindOfPerson.Natural,
                    DateOfBirth = DateTimeOffset.Parse("28-05-1992"),
                    SignUpDate = DateTimeOffset.Parse("12-02-2020"),
                }
            };
            clientRepoMock
                .Setup(n => n.GetAll<ClientEntity>())
                .Returns(listClient);

            var service = new ServiceCollection();
            service.ConfigureAdministrationService(new DbSettings());
            service.AddTransient(_ => clientRepoMock.Object);
            var provider = service.BuildServiceProvider();
            var employeeService = provider.GetRequiredService<IClientService>();

            var client = new ClientDto
            {
                ClientId = Guid.Parse("3dcf7212-0984-4f61-b2b3-8f1c12120fec"),
                FirstName = "Lenny",
                SecondName = "Alexander",
                FirstLastName = "Trejos",
                SecondLastName = "Bermúdez",
                TypePerson = TypeOfPerson.Natural,
                DateOfBirth = DateTimeOffset.Parse("28-05-1991"),
                SignUpDate = DateTimeOffset.Parse("12-02-2021"),
            };

            await Assert.ThrowsAsync<NameClientAlreadyExist>(() => employeeService.AddClient(client)).ConfigureAwait(false);
        }

        [Fact]
        [UnitTest]

        public async Task Date_Of_Birth_And_Date_Creation_Are_Required_For_Client()
        {
            var employeeRepoMock = new Mock<IClientRepositorio>();

            var service = new ServiceCollection();
            service.ConfigureAdministrationService(new DbSettings());
            service.AddTransient(_ => employeeRepoMock.Object);
            var provider = service.BuildServiceProvider();
            var employeeService = provider.GetRequiredService<IClientService>();

            var client = new ClientDto
            {
                FirstName = "Lenny",
                SecondName = "Alexander",
                FirstLastName = "Trejos",
                SecondLastName = "Bermúdez",
                TypePerson = TypeOfPerson.Natural,
               
            };

            await Assert.ThrowsAsync<DateCreationNotExistForClient>(() => employeeService.AddClient(client)).ConfigureAwait(false);
        }

        [Fact]
        [UnitTest]
        public async Task Data_Client_Not_Null()
        {
            var service = new ServiceCollection();
            service.ConfigureAdministrationService(new DbSettings());
            var provider = service.BuildServiceProvider();
            var clientService = provider.GetRequiredService<IClientService>();

            await Assert.ThrowsAsync<ArgumentNullException>(() => clientService.AddClient(null)).ConfigureAwait(false);
            await Assert.ThrowsAsync<ArgumentNullException>(() => clientService.DeleteClient(null)).ConfigureAwait(false);
            await Assert.ThrowsAsync<ArgumentNullException>(() => clientService.UpdateClient(null)).ConfigureAwait(false);
            await Assert.ThrowsAsync<ArgumentNullException>(() => clientService.SearchByIdClient(null)).ConfigureAwait(false);
        }

        [Fact]
        [UnitTest]
        public async Task Searching_Client_By_Id()
        {
            var clientRepoMock = new Mock<IClientRepositorio>();
            clientRepoMock
                .Setup(id => id.SearchMatching(It.IsAny<Expression<Func<ClientEntity, bool>>>()))
                .Returns(new List<ClientEntity>() { new ClientEntity{

                    ClientId = Guid.Parse("ee98a9db-1443-4491-b470-cca353138808"),
                    FirstLastName = "Lenny"

                }});

            var service = new ServiceCollection();
            service.AddTransient(_ => clientRepoMock.Object);
            service.ConfigureAdministrationService(new DbSettings());
            var provider = service.BuildServiceProvider();
            var providerService = provider.GetRequiredService<IClientService>();

            var clients = new ClientDto
            {
               ClientId = Guid.Parse("ee98a9db-1443-4491-b470-cca353138808")
            };

            var response = await providerService.SearchByIdClient(clients).ConfigureAwait(false);
        }

        [Fact]
        [UnitTest]
        public async Task Delete_Client()
        {
            var providerRepoMock = new Mock<IClientRepositorio>();
            providerRepoMock
                .Setup(id => id.SearchMatching(It.IsAny<Expression<Func<ClientEntity, bool>>>()))
                .Returns(new List<ClientEntity> { new ClientEntity
                {
                    ClientId = Guid.Parse("ee98a9db-1443-4491-b470-cca353138808")

                }});

            providerRepoMock
                .Setup(p => p.Delete(It.IsAny<ClientEntity>()))
                .Returns(true);

            var service = new ServiceCollection();
            service.ConfigureAdministrationService(new DbSettings());
            service.AddTransient(_ => providerRepoMock.Object);
            var provider = service.BuildServiceProvider();
            var providerDeleteService = provider.GetRequiredService<IClientService>();

            var clientDelete = new ClientDto
            {
                ClientId = Guid.Parse("ee98a9db-1443-4491-b470-cca353138808")
            };

            var response = await providerDeleteService.DeleteClient(clientDelete).ConfigureAwait(false);
            providerRepoMock.Verify(d => d.Delete(It.IsAny<ClientEntity>()), Times.Once);

            Assert.True(response);
        }

        [Fact]
        [UnitTest]
        public async Task Update_Client()
        {
            var providerRepoMock = new Mock<IClientRepositorio>();
            providerRepoMock
                .Setup(id => id.SearchMatching(It.IsAny<Expression<Func<ClientEntity, bool>>>()))
                .Returns(new List<ClientEntity> { new ClientEntity
                {

                     ClientId = Guid.Parse("ee98a9db-1443-4491-b470-cca353138808")

                }});

            providerRepoMock
                .Setup(p => p.Update(It.IsAny<ClientEntity>()))
                .Returns(true);

            var providers = new ClientDto
            {
                ClientId = Guid.Parse("ee98a9db-1443-4491-b470-cca353138808")
            };

            var service = new ServiceCollection();
            service.AddTransient(_ => providerRepoMock.Object);
            service.ConfigureAdministrationService(new DbSettings());
            var provider = service.BuildServiceProvider();
            var clientUpdateService = provider.GetRequiredService<IClientService>();

            var response = await clientUpdateService.UpdateClient(new ClientDto()).ConfigureAwait(false);
            Assert.True(response);
        }

        [Fact]
        [UnitTest]
        public void Get_All_Client()
        {
            var clientRepoMock = new Mock<IClientRepositorio>();
            clientRepoMock
                .Setup(g => g.GetAll<ClientEntity>())
                .Returns(new List<ClientEntity>(){ new ClientEntity {

                    ClientId =Guid.Parse("ee98a9db-1443-4491-b470-cca353138808"),
                }});

            var service = new ServiceCollection();
            service.AddTransient(_ => clientRepoMock.Object);
            service.ConfigureAdministrationService(new DbSettings());
            var provider = service.BuildServiceProvider();
            var providerGetAllService = provider.GetRequiredService<IClientService>();

            var response = providerGetAllService.GetAllClientDto();
            clientRepoMock.Verify(v => v.GetAll<ClientEntity>(), Times.Once);
        }

        
    }
}
