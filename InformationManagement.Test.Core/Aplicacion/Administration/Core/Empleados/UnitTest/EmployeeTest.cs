using GestionInformacion.Infraestructura.Datos.Persistencia.Core.Base.Configuration;
using InformationManagement.Aplication.Core.Administration.Administration.Configurator;
using InformationManagement.Aplication.Core.Administration.Employees.Services;
using InformationManagement.Aplication.Dto.Administration;
using InformationManagement.Aplication.Dto.Administration.Employees;
using InformationManagement.Dominio.Core.Administracion.Personas;
using InformationManagement.Dominio.Core.Administration;
using InformationManagement.Dominio.Core.Administration.Empleado;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;
using Xunit.Categories;

namespace InformationManagement.Test.Core.Aplicacion.Administration.Core.Empleados
{
    public class EmployeeTest
    {
        [Fact]
        [UnitTest]
        public async Task Data_Employee_Not_Null()
        {
            var service = new ServiceCollection();
            service.ConfigureAdministrationService(new DbSettings());
            var provider = service.BuildServiceProvider();
            var employeeService = provider.GetRequiredService<IEmployeeService>();

            await Assert.ThrowsAsync<ArgumentNullException>(() => employeeService.AddEmployee(null)).ConfigureAwait(false);
            await Assert.ThrowsAsync<ArgumentNullException>(() => employeeService.DeleteEmploye(null)).ConfigureAwait(false);
            await Assert.ThrowsAsync<ArgumentNullException>(() => employeeService.UpdateEmployee(null)).ConfigureAwait(false);
            await Assert.ThrowsAsync<ArgumentNullException>(() => employeeService.SearchByIdEmployee(null)).ConfigureAwait(false);
        }

        [Fact]
        [UnitTest]
        public async Task Name_Employeed_Already_Exist()
        {
            var employeeRepoMock = new Mock<IEmployeeRepositorio>();

            var listEmployee = new List<EmployeeEntity>
            {
                new EmployeeEntity
                {
                    EmployeeCode = Guid.Parse("ee98a9db-1443-4491-b470-cca353138801"),
                    EmployeeId = Guid.Parse("ee98a9db-1443-4491-b470-cca353138844"),
                    Job = "Admin",
                    FirstName = "Lenny",
                    SecondName = "Alexander",
                    FirstLastName = "Trejos",
                    SecondLastName = "Bermúdez",
                    KindOfPerson = KindOfPerson.Juridica,
                    Salary = 1000000,
                    DateOfBirth = DateTimeOffset.Parse("28-05-1992"),
                    SignUpDate = DateTimeOffset.Parse("12-02-2020"),
                }
            };
            employeeRepoMock
                .Setup(n => n.GetAll<EmployeeEntity>())
                .Returns(listEmployee);

            var service = new ServiceCollection();
            service.ConfigureAdministrationService(new DbSettings());
            service.AddTransient(_ => employeeRepoMock.Object);
            var provider = service.BuildServiceProvider();
            var employeeService = provider.GetRequiredService<IEmployeeService>();

            var employee = new EmployeeDto
            {
                EmployeeCode = Guid.Parse("ee98a9db-1443-4491-b470-cca353138808"),
                EmployeeId = Guid.Parse("ee98a9db-1443-4491-b470-cca353138848"),
                job = "Admin",
                FirstName = "Lenny",
                SecondName = "Alexander",
                FirstLastName = "Trejos",
                SecondLastName = "Bermúdez",
                TypePerson = TypeOfPerson.Juridica,
                Salary = 1000000,
                DateOfBirth = DateTimeOffset.Parse("28-05-1991"),
                SignUpDate = DateTimeOffset.Parse("12-02-2021"),
            };

            await Assert.ThrowsAsync<NameEmployeeAlreadyExist>(() => employeeService.AddEmployee(employee)).ConfigureAwait(false);
        }

        [Fact]
        [UnitTest]

        public async Task Employee_With_The_Same_Code_And_Id_Is_Not_Permitted()
        {
            var employeeRepoMock = new Mock<IEmployeeRepositorio>();

            var listEmployee = new List<EmployeeEntity>
            {
                new EmployeeEntity
                {
                    EmployeeCode = Guid.Parse("ee98a9db-1443-4491-b470-cca353138808"),
                    EmployeeId = Guid.Parse("ee98a9db-1443-4491-b470-cca353138848"),
                    Job = "Admin",
                    FirstName = "Lenny",
                    SecondName = "Alexander",
                    FirstLastName = "Trejos",
                    SecondLastName = "Bermúdez",
                    KindOfPerson = KindOfPerson.Natural,
                    Salary = 1000000,
                    DateOfBirth = DateTimeOffset.Parse("28-05-1992"),
                    SignUpDate = DateTimeOffset.Parse("12-02-2020"),
                }
            };
            employeeRepoMock
                .Setup(m => m.GetAll<EmployeeEntity>())
                .Returns(listEmployee);

            var service = new ServiceCollection();
            service.ConfigureAdministrationService(new DbSettings());
            service.AddTransient(_ => employeeRepoMock.Object);
            var provider = service.BuildServiceProvider();
            var employeeService = provider.GetRequiredService<IEmployeeService>();

            var employee = new EmployeeDto
            {
                EmployeeCode = Guid.Parse("ee98a9db-1443-4491-b470-cca353138808"),
                EmployeeId = Guid.Parse("ee98a9db-1443-4491-b470-cca353138848"),
                job = "Admin",
                FirstName = "Lenny",
                SecondName = "Alexander",
                FirstLastName = "Trejos",
                SecondLastName = "Bermúdez",
                TypePerson = TypeOfPerson.Juridica,
                Salary = 1000000,
                DateOfBirth = DateTimeOffset.Parse("28-05-1991"),
                SignUpDate = DateTimeOffset.Parse("12-02-2021"),
            };

            await Assert.ThrowsAsync<CodeIdEmployeeAlreadyExist>(() => employeeService.AddEmployee(employee)).ConfigureAwait(false);
        }

        [Fact]
        [UnitTest]

        public async Task Employee_Can_Not_be_Legal_Person()
        {
            var employeeRepoMock = new Mock<IEmployeeRepositorio>();
            
            var service = new ServiceCollection();
            service.ConfigureAdministrationService(new DbSettings());
            service.AddTransient(_ => employeeRepoMock.Object);
            var provider = service.BuildServiceProvider();
            var employeeService = provider.GetRequiredService<IEmployeeService>();

            var employee = new EmployeeDto
            {
                EmployeeCode = Guid.Parse("ee98a9db-1443-4491-b470-cca353138808"),
                EmployeeId = Guid.Parse("ee98a9db-1443-4491-b470-cca353138848"),
                job = "Admin",
                FirstName = "Lenny",
                SecondName = "Alexander",
                FirstLastName = "Trejos",
                SecondLastName = "Bermúdez",
                TypePerson = TypeOfPerson.Juridica,
                Salary = 1000000,
                DateOfBirth = DateTimeOffset.Parse("28-05-1992"),
                SignUpDate = DateTimeOffset.Parse("12-02-2020"),
            };
          
            await Assert.ThrowsAsync<EmployeeIsNotLegalPerson>(()=>employeeService.AddEmployee(employee)).ConfigureAwait(false);
        }

        [Fact]
        [UnitTest]

        public async Task Date_Of_Birth_And_Date_Creation_Are_Required_For_Employee()
        {
            var employeeRepoMock = new Mock<IEmployeeRepositorio>();

            var listEmployee = new List<EmployeeEntity>
                {
                    new EmployeeEntity
                    {
                        EmployeeCode = Guid.Parse("8dd50b8b-5718-4c15-bdc8-ca72e3efb04f"),
                        EmployeeId = Guid.Parse("4a5668aa-6752-45cd-92c5-306fe8a15801"),
                        
                        FirstName = "Lenn",
                        SecondName = "Alexande",
                        FirstLastName = "Trejo",
                        SecondLastName = "Bermúde",
                        KindOfPerson = KindOfPerson.Natural,
                        Salary = 1000000,
                        //DateOfBirth = DateTimeOffset.Parse("28-05-1991"),
                        //SignUpDate = DateTimeOffset.Parse("12-02-2021"),
                    }
                };

            employeeRepoMock
                .Setup(e => e.GetAll<EmployeeEntity>())
                .Returns(listEmployee);

            var service = new ServiceCollection();
            service.ConfigureAdministrationService(new DbSettings());
            service.AddTransient(_ => employeeRepoMock.Object);
            var provider = service.BuildServiceProvider();
            var employeeService = provider.GetRequiredService<IEmployeeService>();

            var employee = new EmployeeDto
            {
                EmployeeCode = Guid.Parse("ee98a9db-1443-4491-b470-cca353138808"),
                EmployeeId = Guid.Parse("ee98a9db-1443-4491-b470-cca353138848"),
                job = "Admin",
                FirstName = "Lenny",
                SecondName = "Alexander",
                FirstLastName = "Trejos",
                SecondLastName = "Bermúdez",
                TypePerson = TypeOfPerson.Natural,
                Salary = 1000000,
                
            };

            await Assert.ThrowsAsync<DateCreationNotExist>(() => employeeService.AddEmployee(employee)).ConfigureAwait(false);
        }

        [Fact]
        [UnitTest]

        public async Task Employee_Can_Not_Have_Nit()
        {
            var employeeRepoMock = new Mock<IEmployeeRepositorio>();

            var service = new ServiceCollection();
            service.ConfigureAdministrationService(new DbSettings());
            service.AddTransient(_ => employeeRepoMock.Object);
            var provider = service.BuildServiceProvider();
            var employeeService = provider.GetRequiredService<IEmployeeService>();

            var employee = new EmployeeDto
            {
                EmployeeCode = Guid.Parse("ee98a9db-1443-4491-b470-cca353138806"),
                EmployeeId = Guid.Parse("ee98a9db-1443-4491-b450-cca353138848"),
                job = "Admin",
                FirstName = "Lenny",
                SecondName = "Alexader",
                FirstLastName = "Trejos",
                SecondLastName = "Bermúdez",
                TypePerson = TypeOfPerson.Natural,
                TypeDocument = Type_Document.Nit,
                Salary = 1000000,
                DateOfBirth = DateTimeOffset.Parse("28-05-1992"),
                SignUpDate = DateTimeOffset.Parse("12-02-2020"),
                
            };

            await Assert.ThrowsAsync<EmployeeHaveNotNit>(() => employeeService.AddEmployee(employee)).ConfigureAwait(false);
        }

        [Fact]
        [UnitTest]
        public async Task Searching_Employee_By_Id()
        {
            var employeeRepoMock = new Mock<IEmployeeRepositorio>();
            employeeRepoMock
                .Setup(id => id.SearchMatching(It.IsAny<Expression<Func<EmployeeEntity, bool>>>()))
                .Returns(new List<EmployeeEntity>() { new EmployeeEntity{

                    EmployeeCode = Guid.Parse("9181b7a4-cf93-47ff-ae3e-7c6cc7c66ba8"),
                    EmployeeId = Guid.Parse("ee98a9db-1443-4491-b470-cca353138808")

                }});

            var service = new ServiceCollection();
            service.AddTransient(_ => employeeRepoMock.Object);
            service.ConfigureAdministrationService(new DbSettings());
            var provider = service.BuildServiceProvider();
            var employeeIdService = provider.GetRequiredService<IEmployeeService>();

            var employee = new EmployeeDto
            {
                EmployeeCode = Guid.Parse("f0e6b55b-f4ff-48a5-8969-e02081dec607"),
                EmployeeId = Guid.Parse("ee98a9db-1443-4491-b470-cca353138808")

            };

            var response = await employeeIdService.SearchByIdEmployee(employee).ConfigureAwait(false);
            
        }

        [Fact]
        [UnitTest]
        public async Task Delete_Employee()
        {
            var employeeRepoMock = new Mock<IEmployeeRepositorio>();
            employeeRepoMock
                .Setup(id => id.SearchMatching(It.IsAny<Expression<Func<EmployeeEntity, bool>>>()))
                .Returns(new List<EmployeeEntity> { new EmployeeEntity
                {

                    EmployeeId = Guid.Parse("d6e937b2-9966-418e-a022-b342ebfeb09a"),
                    EmployeeCode = Guid.Parse("5fdeb8c0-3ad8-4605-b692-3f5f99d3a606"),
                    AreaId = Guid.Parse("76fee93f-a9b6-48ef-9983-06f2e584d02d")

                }});

            employeeRepoMock
                .Setup(d => d.Delete(It.IsAny<EmployeeEntity>()))
                .Returns(true);

            var service = new ServiceCollection();
            service.ConfigureAdministrationService(new DbSettings());
            service.AddTransient(_ => employeeRepoMock.Object);
            var provider = service.BuildServiceProvider();
            var employeeDeleteService = provider.GetRequiredService<IEmployeeService>();

            var employee = new EmployeeDto
            {

                EmployeeId = Guid.Parse("d6e937b2-9966-418e-a022-b342ebfeb09a"),
                EmployeeCode = Guid.Parse("5fdeb8c0-3ad8-4605-b692-3f5f99d3a606"),
                job = "Admin",
                FirstName = "Lenny",
                SecondName = "Alexander",
                FirstLastName = "Trejos",
                SecondLastName = "Bermúdez",
                Salary = 1000000,
                DateOfBirth = DateTimeOffset.Parse("28-05-1991"),
                SignUpDate = DateTimeOffset.Parse("12-02-2021"),
            };


            var response = await employeeDeleteService.DeleteEmploye(employee).ConfigureAwait(false);
            employeeRepoMock.Verify(d => d.Delete(It.IsAny<EmployeeEntity>()), Times.Once);

            Assert.True(response);
        }

        [Fact]
        [UnitTest]
        public async Task Update_Employee()
        {
            var employeeRepoMock = new Mock<IEmployeeRepositorio>();
            employeeRepoMock
                .Setup(id => id.SearchMatching(It.IsAny<Expression<Func<EmployeeEntity, bool>>>()))
                .Returns(new List<EmployeeEntity> { new EmployeeEntity
                {

                    EmployeeId = Guid.Parse("d6e937b2-9966-418e-a022-b342ebfeb09a"),
                    EmployeeCode = Guid.Parse("5fdeb8c0-3ad8-4605-b692-3f5f99d3a606"),
                    AreaId = Guid.Parse("76fee93f-a9b6-48ef-9983-06f2e584d02d")

                }});

            employeeRepoMock
                .Setup(d => d.Update(It.IsAny<EmployeeEntity>()))
                .Returns(true);

            var employee = new EmployeeDto
            {
                EmployeeId = Guid.Parse("d6e937b2-9966-418e-a022-b342ebfeb09a"),
                EmployeeCode = Guid.Parse("5fdeb8c0-3ad8-4605-b692-3f5f99d3a606"),

            };

            var service = new ServiceCollection();
            service.AddTransient(_ => employeeRepoMock.Object);
            service.ConfigureAdministrationService(new DbSettings());
            var provider = service.BuildServiceProvider();
            var areaUpdateService = provider.GetRequiredService<IEmployeeService>();

            var response = await areaUpdateService.UpdateEmployee(new EmployeeDto()).ConfigureAwait(false);
            Assert.True(response);
        }

        [Fact]
        [UnitTest]
        public void Get_All_Employee()
        {
            var areaRepoMock = new Mock<IEmployeeRepositorio>();
            areaRepoMock
                .Setup(g => g.GetAll<EmployeeEntity>())
                .Returns(new List<EmployeeEntity>(){ new EmployeeEntity {

                    EmployeeId = Guid.Parse("d6e937b2-9966-418e-a022-b342ebfeb09a"),
                    EmployeeCode = Guid.Parse("5fdeb8c0-3ad8-4605-b692-3f5f99d3a606"),
                    AreaId = Guid.Parse("76fee93f-a9b6-48ef-9983-06f2e584d02d")

                }});

            var service = new ServiceCollection();
            service.AddTransient(_ => areaRepoMock.Object);
            service.ConfigureAdministrationService(new DbSettings());
            var provider = service.BuildServiceProvider();
            var employeeGetAllService = provider.GetRequiredService<IEmployeeService>();

            var response = employeeGetAllService.GetAllEmployeeDto();
            areaRepoMock.Verify(v => v.GetAll<EmployeeEntity>(), Times.Once);
        }

    }
}
