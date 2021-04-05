using GestionInformacion.Infraestructura.Datos.Persistencia.Core.Base.Configuration;
using InformationManagement.Aplication.Core.Administration.Administration.Configurator;
using InformationManagement.Aplication.Core.Administration.Providers.Services;
using InformationManagement.Aplication.Dto.Administration;
using InformationManagement.Aplication.Dto.Administration.Providers;
using InformationManagement.Dominio.Core.Administracion.Personas;
using InformationManagement.Dominio.Core.Administration;
using InformationManagement.Dominio.Core.Administration.Proveedor;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;
using Xunit.Categories;

namespace InformationManagement.Test.Core.Aplicacion.Administration.Core.Providers.UnitTestProviders
{
    public class ProviderTest
    {
        [Fact]
        [UnitTest]
        public async Task Data_Provider_Not_Null()
        {
            var service = new ServiceCollection();
            service.ConfigureAdministrationService(new DbSettings());
            var provider = service.BuildServiceProvider();
            var providerService = provider.GetRequiredService<IProviderService>();

            await Assert.ThrowsAsync<ArgumentNullException>(() => providerService.AddProvider(null)).ConfigureAwait(false);
            await Assert.ThrowsAsync<ArgumentNullException>(() => providerService.DeleteProvider(null)).ConfigureAwait(false);
            await Assert.ThrowsAsync<ArgumentNullException>(() => providerService.UpdateProvider(null)).ConfigureAwait(false);
            await Assert.ThrowsAsync<ArgumentNullException>(() => providerService.SearchByIdProvider(null)).ConfigureAwait(false);
        }

        [Fact]
        [UnitTest]

        public async Task Provider_Employee_Can_Not_Have_Type_Identification_Nit()
        {
            var providerRepoMock = new Mock<IProviderRepositorio>();
            
            var service = new ServiceCollection();
            service.AddTransient(_ => providerRepoMock.Object);
            service.ConfigureAdministrationService(new DbSettings());
            var provider = service.BuildServiceProvider();
            var providerService = provider.GetRequiredService<IProviderService>();

            var response = new ProviderDto
            {

                IdProvider = Guid.Parse("3dcf7212-0984-4f61-b2b3-8f1c12120fec"),
                CompanyName = "SYP",
                FirstName = "Lenny",
                SecondName = "Alexander",
                FirstLastName = "Trejos",
                SecondLastName = "Bermúdez",
                TypeDocument = Type_Document.Nit,
                TypePerson = TypeOfPerson.Natural,
                DateOfBirth = DateTimeOffset.Parse("28-05-1991"),
                SignUpDate = DateTimeOffset.Parse("12-02-2021"),

            };

            await Assert.ThrowsAsync<ProviderEmployeeHaveNotNit>(() => providerService.AddProvider(response)).ConfigureAwait(false);
        }

        [Fact]
        [UnitTest]

        public async Task Name_Provider_Employee_Already_Exist()
        {
            var providerRepoMock = new Mock<IProviderRepositorio>();

            var listProvider = new List<ProviderEntity>
            {
                new ProviderEntity
                {
                    IdProvider = Guid.Parse("3dcf7212-0984-4f61-b2b3-8f1c12120fec"),
                    CompanyName = "SYP",
                    FirstName = "Lenny",
                    SecondName = "Alexander",
                    FirstLastName = "Trejos",
                    SecondLastName = "Bermúdez",
                    TypeDocument = Dominio.Core.Administration.TypeDocument.Nit,
                    DateOfBirth = DateTimeOffset.Parse("28-05-1992"),
                    SignUpDate = DateTimeOffset.Parse("12-02-2020"),
                }
            };
            providerRepoMock
                .Setup(n => n.GetAll<ProviderEntity>())
                .Returns(listProvider);

            var service = new ServiceCollection();
            service.ConfigureAdministrationService(new DbSettings());
            service.AddTransient(_ => providerRepoMock.Object);
            var provider = service.BuildServiceProvider();
            var employeeService = provider.GetRequiredService<IProviderService>();

            var providers = new ProviderDto
            {
                IdProvider = Guid.Parse("3dcf7212-0984-4f61-b2b3-8f1c12120fec"),
                CompanyName = "SYP",
                FirstName = "Lenny",
                SecondName = "Alexander",
                FirstLastName = "Trejos",
                SecondLastName = "Bermúdez",
                TypeDocument = Type_Document.Nit,
                TypePerson = TypeOfPerson.Natural,
                DateOfBirth = DateTimeOffset.Parse("28-05-1991"),
                SignUpDate = DateTimeOffset.Parse("12-02-2021"),
            };

            await Assert.ThrowsAsync<NameProviderAlreadyExist>(() => employeeService.AddProvider(providers)).ConfigureAwait(false);
        }

        [Fact]
        [UnitTest]

        public async Task Name_Provider_Already_Exist()
        {
            var providerRepoMock = new Mock<IProviderRepositorio>();

            var listProvider = new List<ProviderEntity>
            {
                new ProviderEntity
                {
                    IdProvider = Guid.Parse("3dcf7212-0984-4f61-b2b3-8f1c12120fec"),
                    CompanyName = "SYP",
                    FirstName = "Lenny",
                    SecondName = "Alexander",
                    FirstLastName = "Trejos",
                    SecondLastName = "Bermúdez",
                    TypeDocument = Dominio.Core.Administration.TypeDocument.Nit,
                    DateOfBirth = DateTimeOffset.Parse("28-05-1992"),
                    SignUpDate = DateTimeOffset.Parse("12-02-2020"),
                }
            };
            providerRepoMock
                .Setup(n => n.GetAll<ProviderEntity>())
                .Returns(listProvider);

            var service = new ServiceCollection();
            service.ConfigureAdministrationService(new DbSettings());
            service.AddTransient(_ => providerRepoMock.Object);
            var provider = service.BuildServiceProvider();
            var employeeService = provider.GetRequiredService<IProviderService>();

            var providers = new ProviderDto
            {
                IdProvider = Guid.Parse("3dcf7212-0984-4f61-b2b3-8f1c12120fec"),
                CompanyName = "SYP",
                FirstName = "Lenn",
                SecondName = "Alexander",
                FirstLastName = "Trejos",
                SecondLastName = "Bermúdez",
                TypePerson = TypeOfPerson.Natural,
                TypeDocument = Type_Document.Cedula,
                DateOfBirth = DateTimeOffset.Parse("28-05-1991"),
                SignUpDate = DateTimeOffset.Parse("12-02-2021"),

            };

            await Assert.ThrowsAsync<NameCompanyAlreadyExist>(() => employeeService.AddProvider(providers)).ConfigureAwait(false);
        }

        [Fact]
        [UnitTest]

        public async Task Date_Of_Birth_And_Date_Creation_Are_Required_For_Provider_And_Employee()
        {
            var providerRepoMock = new Mock<IProviderRepositorio>();

            var service = new ServiceCollection();
            service.ConfigureAdministrationService(new DbSettings());
            service.AddTransient(_ => providerRepoMock.Object);
            var provider = service.BuildServiceProvider();
            var providerService = provider.GetRequiredService<IProviderService>();

            var providers = new ProviderDto
            {
                FirstName = "Lenny",
                SecondName = "Alexander",
                FirstLastName = "Trejos",
                SecondLastName = "Bermúdez",
                TypePerson = TypeOfPerson.Natural,

            };

            await Assert.ThrowsAsync<DateCreationNotExistForProvider>(() => providerService.AddProvider(providers)).ConfigureAwait(false);
        }

        [Fact]
        [UnitTest]
        public async Task Provider_With_The_Same_Nit_Is_Not_Permitted()
        {
            var providerRepoMock = new Mock<IProviderRepositorio>();

            var listProvider = new List<ProviderEntity>
            {
                new ProviderEntity
                {
                    IdProvider = Guid.Parse("ee98a9db-1443-4491-b470-cca353138847"),
                    FirstName = "Lenny",
                    SecondName = "Alexander",
                    FirstLastName = "Trejos",
                    SecondLastName = "Bermúez",
                    KindOfPerson = KindOfPerson.Natural,
                    DateOfBirth = DateTimeOffset.Parse("28-05-1992"),
                    SignUpDate = DateTimeOffset.Parse("12-02-2020"),
                    NitCompany = Guid.Parse("cd61bfc6-3ad9-4d47-8e83-7e3eb4b86c6f"),
                }
            };
            providerRepoMock
                .Setup(m => m.GetAll<ProviderEntity>())
                .Returns(listProvider);

            var service = new ServiceCollection();
            service.ConfigureAdministrationService(new DbSettings());
            service.AddTransient(_ => providerRepoMock.Object);
            var provider = service.BuildServiceProvider();
            var providerService = provider.GetRequiredService<IProviderService>();

            var providers = new ProviderDto
            {
                IdProvider = Guid.Parse("ee98a9db-1443-4491-b470-cca353138848"),
                CompanyName = "SYP",
                FirstName = "Lenny",
                SecondName = "Alexander",
                FirstLastName = "Trejos",
                SecondLastName = "Bermúde",
                TypePerson = TypeOfPerson.Natural,
                DateOfBirth = DateTimeOffset.Parse("28-05-1992"),
                SignUpDate = DateTimeOffset.Parse("12-02-2020"),
                NitCompany = Guid.Parse("cd61bfc6-3ad9-4d47-8e83-7e3eb4b86c6f"),
            };

            await Assert.ThrowsAsync<NitProviderAlreadyExist>(() => providerService.AddProvider(providers)).ConfigureAwait(false);
        }
        
        [Fact]
        [UnitTest]
        public async Task Provider_With_The_Same_Id_Is_Not_Permitted()
        {
            var providerRepoMock = new Mock<IProviderRepositorio>();

            var listProvider = new List<ProviderEntity>
            {
                new ProviderEntity
                {
                    IdProvider = Guid.Parse("3dcf7212-0984-4f61-b2b3-8f1c12120fec"),
                    FirstName = "Lenny",
                    SecondName = "Alexander",
                    FirstLastName = "Trejos",
                    SecondLastName = "Bermúez",
                    KindOfPerson = KindOfPerson.Natural,
                    DateOfBirth = DateTimeOffset.Parse("28-05-1992"),
                    SignUpDate = DateTimeOffset.Parse("12-02-2020"),
                    TypeDocument = TypeDocument.Nit,
                    NitCompany = Guid.Parse("cd61bfc6-3ad9-4d47-8e83-7e3eb4b86c6f"),
                    CompanyName = "SYP_",
                }
            };
            providerRepoMock
                .Setup(m => m.GetAll<ProviderEntity>())
                .Returns(listProvider);

            var service = new ServiceCollection();
            service.ConfigureAdministrationService(new DbSettings());
            service.AddTransient(_ => providerRepoMock.Object);
            var provider = service.BuildServiceProvider();
            var providerService = provider.GetRequiredService<IProviderService>();

            var providers = new ProviderDto
            {
                IdProvider = Guid.Parse("3dcf7212-0984-4f61-b2b3-8f1c12120fec"),
                FirstName = "Lenn",
                SecondName = "Alexander",
                FirstLastName = "Trejos",
                SecondLastName = "Bermúdez",
                TypePerson = TypeOfPerson.Natural,
                DateOfBirth = DateTimeOffset.Parse("28-05-1992"),
                SignUpDate = DateTimeOffset.Parse("12-02-2020"),
                CompanyName = "SYP",
                NitCompany = Guid.Parse("cd81bfc6-3ad9-4d47-8e83-7e3eb4b86c6f"),
                TypeDocument = Type_Document.Pasaporte
            };

            await Assert.ThrowsAsync<IdProviderEmployeeAlreadyExist>(() => providerService.AddProvider(providers)).ConfigureAwait(false);
        }


        [Fact]
        [UnitTest]
        public async Task Searching_Provider_By_Id()
        {
            var providerRepoMock = new Mock<IProviderRepositorio>();
            providerRepoMock
                .Setup(id => id.SearchMatching(It.IsAny<Expression<Func<ProviderEntity, bool>>>()))
                .Returns(new List<ProviderEntity>() { new ProviderEntity{

                    IdProvider = Guid.Parse("ee98a9db-1443-4491-b470-cca353138808")

                }});

            var service = new ServiceCollection();
            service.AddTransient(_ => providerRepoMock.Object);
            service.ConfigureAdministrationService(new DbSettings());
            var provider = service.BuildServiceProvider();
            var providerService = provider.GetRequiredService<IProviderService>();

            var providers = new ProviderDto
            {
                IdProvider = Guid.Parse("ee98a9db-1443-4491-b470-cca353138808")
            };

            var response = await providerService.SearchByIdProvider(providers).ConfigureAwait(false);
        }

        [Fact]
        [UnitTest]
        public async Task Delete_Provider()
        {
            var providerRepoMock = new Mock<IProviderRepositorio>();
            providerRepoMock
                .Setup(id => id.SearchMatching(It.IsAny<Expression<Func<ProviderEntity, bool>>>()))
                .Returns(new List<ProviderEntity> { new ProviderEntity
                {
                    IdProvider = Guid.Parse("ee98a9db-1443-4491-b470-cca353138808"),
                    CompanyName = "Compañía 1",
                    ContactNumber = 3215553058

                }});

            providerRepoMock
                .Setup(p => p.Delete(It.IsAny<ProviderEntity>()))
                .Returns(true);

            var service = new ServiceCollection();
            service.ConfigureAdministrationService(new DbSettings());
            service.AddTransient(_ => providerRepoMock.Object);
            var provider = service.BuildServiceProvider();
            var providerDeleteService = provider.GetRequiredService<IProviderService>();

            var providerDelete = new ProviderDto
            {
                IdProvider = Guid.Parse("ee98a9db-1443-4491-b470-cca353138808"),
                CompanyName = "Compañía 1",
                ContactNumber = 3215553058
            };

            var response = await providerDeleteService.DeleteProvider(providerDelete).ConfigureAwait(false);
            providerRepoMock.Verify(d => d.Delete(It.IsAny<ProviderEntity>()), Times.Once);

            Assert.True(response);
        }

        [Fact]
        [UnitTest]
        public async Task Update_Employee()
        {
            var providerRepoMock = new Mock<IProviderRepositorio>();
            providerRepoMock
                .Setup(id => id.SearchMatching(It.IsAny<Expression<Func<ProviderEntity, bool>>>()))
                .Returns(new List<ProviderEntity> { new ProviderEntity
                {

                    IdProvider = Guid.Parse("ee98a9db-1443-4491-b470-cca353138808"),
                    CompanyName = "Compañía 1",
                    ContactNumber = 3215553058

                }});

            providerRepoMock
                .Setup(p => p.Update(It.IsAny<ProviderEntity>()))
                .Returns(true);

            var providers = new ProviderDto
            {
                IdProvider = Guid.Parse("ee98a9db-1443-4491-b470-cca353138808"),
                CompanyName = "Compañía 1",
                ContactNumber = 3215553058
            };

            var service = new ServiceCollection();
            service.AddTransient(_ => providerRepoMock.Object);
            service.ConfigureAdministrationService(new DbSettings());
            var provider = service.BuildServiceProvider();
            var providerUpdateService = provider.GetRequiredService<IProviderService>();

            var response = await providerUpdateService.UpdateProvider(new ProviderDto()).ConfigureAwait(false);
            Assert.True(response);
        }

        [Fact]
        [UnitTest]
        public void Get_All_Provider()
        {
            var providerRepoMock = new Mock<IProviderRepositorio>();
            providerRepoMock
                .Setup(g => g.GetAll<EmployeeEntity>())
                .Returns(new List<EmployeeEntity>(){ new EmployeeEntity {

                    EmployeeId = Guid.Parse("d6e937b2-9966-418e-a022-b342ebfeb09a"),
                    EmployeeCode = Guid.Parse("5fdeb8c0-3ad8-4605-b692-3f5f99d3a606"),
                    AreaId = Guid.Parse("76fee93f-a9b6-48ef-9983-06f2e584d02d")

                }});

            var service = new ServiceCollection();
            service.AddTransient(_ => providerRepoMock.Object);
            service.ConfigureAdministrationService(new DbSettings());
            var provider = service.BuildServiceProvider();
            var providerGetAllService = provider.GetRequiredService<IProviderService>();

            var response = providerGetAllService.GetAllProviderDto();
            providerRepoMock.Verify(v => v.GetAll<ProviderEntity>(), Times.Once);
        }
    }
}
