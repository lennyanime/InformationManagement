using InformationManagement.Dominio.Core.Administracion.Personas;
using InformationManagement.Dominio.Core.Administration.Areas;
using InformationManagement.Dominio.Core.Administration.Empleado;
using InformationManagement.Dominio.Core.Areas;
using GestionInformacion.Infraestructura.Datos.Persistencia.Core.Base.Configuration;
using InformationManagement.Aplication.Core.Administration.Administration.Configurator;
using InformationManagement.Aplication.Core.Administration.Areas;
using InformationManagement.Aplication.Core.Administration.Exceptions.Areas;
using InformationManagement.Aplication.Dto.Administration.Areas;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;
using Xunit.Categories;

namespace InformationManagement.Test.Core.Aplicacion.Administration.Core.Areas.UnitTestAreas
{
    public class AreaTest
    {
        [Fact]
        [UnitTest]
        public async Task Administration_Area_Not_Null()
        {
            var service = new ServiceCollection();
            service.ConfigureAdministrationService(new DbSettings());
            var provider = service.BuildServiceProvider();
            var areaService = provider.GetRequiredService<IAreaService>();

            await Assert.ThrowsAsync<ArgumentNullException>(() => areaService.AddArea(null)).ConfigureAwait(false);
            await Assert.ThrowsAsync<ArgumentNullException>(() => areaService.DeleteArea(null)).ConfigureAwait(false);
            await Assert.ThrowsAsync<ArgumentNullException>(() => areaService.UpdateArea(null)).ConfigureAwait(false);
            await Assert.ThrowsAsync<ArgumentNullException>(() => areaService.SearchAreaById(null)).ConfigureAwait(false);
        }

        [Fact]
        [UnitTest]
        public async Task Employee_In_Production_Not_Exist()
        {
            var areaRepoMock = new Mock<IEmployeeRepositorio>();
            //areaRepoMock
            //    .Setup(e => e.SearchMatching(It.IsAny<Expression<Func<EmployeeEntity, bool>>>()))
            //    .Returns(new List<EmployeeEntity> { new EmployeeEntity
            //    {
            //        EmployeeId= Guid.Parse("de9af5f7-3279-465e-a608-961e635ae2e3"),


            //    } });

            var service = new ServiceCollection();
            service.AddTransient(_ => areaRepoMock.Object);
            service.ConfigureAdministrationService(new DbSettings());
            var provider = service.BuildServiceProvider();
            var areaService = provider.GetRequiredService<IAreaService>();

            var response = new AreaDto
            {
                ResponsableEmployedId = default,

                AreaName = default,

                AreaId = default,

            };

            await Assert.ThrowsAsync<EmployeedNotExistInArea>(() => areaService.AddArea(response)).ConfigureAwait(false);
        }

        [Fact]
        [UnitTest]

        public async Task Employeed_Assigned_To_An_Only_Area()
        {
            var areaRepoMock = new Mock<IAreaRepositorio>();
            areaRepoMock
                .Setup(id => id.SearchMatching(It.IsAny<Expression<Func<AreaEntity, bool>>>()))
                .Returns(new List<AreaEntity>() { new AreaEntity{

                    ResponsableEmployedId = Guid.Parse("de9af5f7-3279-465e-a608-961e635ae2e2"),
                    AreaId = Guid.Parse("ee98a9db-1443-4491-b470-cca353138808"),
                    AreaName = "Área1"
                }});

           
            var service = new ServiceCollection();
            service.AddTransient(_ => areaRepoMock.Object);
            service.ConfigureAdministrationService(new DbSettings());
            var provider = service.BuildServiceProvider();
            var areaService = provider.GetRequiredService<IAreaService>();

            var response = new AreaDto
            {
                ResponsableEmployedId = Guid.Parse("de9af5f7-3279-465e-a608-961e635ae2e2"),

                AreaName = "Área 721",

                AreaId = Guid.Parse("6e80402f-20c1-4a3d-9130-afcda32568ed")

            };

            await Assert.ThrowsAsync<TheEmployeedAlreadyIsInAnArea>(() => areaService.AddArea(response)).ConfigureAwait(false);
        }

        [Fact]
        [UnitTest]

        public async Task Searching_Area_By_Id()
        {
            var areaRepoMock = new Mock<IAreaRepositorio>();
            areaRepoMock
                .Setup(id => id.SearchMatching(It.IsAny<Expression<Func<AreaEntity, bool>>>()))
                .Returns(new List<AreaEntity>() { new AreaEntity{

                    ResponsableEmployedId = Guid.NewGuid(),
                    AreaId = Guid.Parse("ee98a9db-1443-4491-b470-cca353138808"),
                    AreaName = "Área1"
                }});


            var service = new ServiceCollection();
            service.AddTransient(_ => areaRepoMock.Object);
            service.ConfigureAdministrationService(new DbSettings());
            var provider = service.BuildServiceProvider();
            var areaIdService = provider.GetRequiredService<IAreaService>();

            var area = new AreaDto
            {
                ResponsableEmployedId = Guid.NewGuid(),
                AreaId = Guid.Parse("ee98a9db-1443-4491-b470-cca353138808"),
                AreaName = "Área1"
            };

            var response = await areaIdService.SearchAreaById(area).ConfigureAwait(false);

            Assert.Equal(area.AreaId, response.AreaId);
        }

        [Fact]
        [UnitTest]
        public async Task Delete_Area()
        {
            var areaRepoMock = new Mock<IAreaRepositorio>();
            areaRepoMock
                .Setup(ida => ida.SearchMatching(It.IsIn<Expression<Func<AreaEntity, bool>>>(d => d.AreaId == Guid.NewGuid())))
                .Returns(new List<AreaEntity>() { new AreaEntity{

                    ResponsableEmployedId = Guid.Parse("73eba8ff-630c-4301-8988-57f5ba5e9e6c"),
                    AreaId = Guid.Parse("ee98a9db-1443-4491-b470-cca353138808"),
                    AreaName = "Área1"
                }});

            areaRepoMock
                .Setup(d => d.Delete(It.IsAny<AreaEntity>()))
                .Returns(true);

            var employeeRepoMock = new Mock<IEmployeeRepositorio>();
            employeeRepoMock
                .Setup(ide => ide.SearchMatching(It.IsIn<Expression<Func<EmployeeEntity, bool>>>(e => e.AreaId == Guid.NewGuid())))
                .Returns(new List<EmployeeEntity>() { new EmployeeEntity{

                    EmployeeId = Guid.Parse("73eba8ff-630c-4301-8988-57f5ba5e9e6c")

                }});

            var service = new ServiceCollection();
            service.AddTransient(_ => areaRepoMock.Object);
            service.AddTransient(_ => employeeRepoMock.Object);
            service.ConfigureAdministrationService(new DbSettings());
            var provider = service.BuildServiceProvider();
            var areaDeleteService = provider.GetRequiredService<IAreaService>();

            var response = await areaDeleteService.DeleteArea(new AreaDto()).ConfigureAwait(false);
            //areaRepoMock.Verify(a => a.SearchMatching(It.IsIn<Expression<Func<AreaEntity, bool>>>(d => d.AreaId == Guid.NewGuid())), Times.Once);
            //areaRepoMock.Verify(a => a.SearchMatching(It.IsIn<Expression<Func<EmployeeEntity, bool>>>(e => e.AreaId == Guid.NewGuid())), Times.Once);
            areaRepoMock.Verify(d => d.Delete(It.IsAny<AreaEntity>()), Times.Once);

            Assert.True(response);
        }

        [Fact]
        [UnitTest]
        public async Task Update_Area()
        {
            var areaRepoMock = new Mock<IAreaRepositorio>();
            areaRepoMock
                .Setup(u => u.SearchMatching(It.IsAny<Expression<Func<AreaEntity, bool>>>()))
                .Returns(new List<AreaEntity>() { new AreaEntity{

                    ResponsableEmployedId = Guid.Parse("73eba8ff-630c-4301-8988-57f5ba5e9e6c"),
                    AreaId = Guid.Parse("ee98a9db-1443-4491-b470-cca353138808"),
                    AreaName = "Área1"
                }});
            //este es otro método
            areaRepoMock
                .Setup(a => a.Update(It.IsAny<AreaEntity>()))
                .Returns(true);

            var area = new AreaDto
            {
                ResponsableEmployedId = Guid.NewGuid(),
                AreaId = Guid.Parse("ee98a9db-1443-4491-b470-cca353138808"),
                AreaName = "Área1"
            };

            var service = new ServiceCollection();
            service.AddTransient(_ => areaRepoMock.Object);
            service.ConfigureAdministrationService(new DbSettings());
            var provider = service.BuildServiceProvider();
            var areaUpdateService = provider.GetRequiredService<IAreaService>();

            var response = await areaUpdateService.UpdateArea(new AreaDto()).ConfigureAwait(false);
            Assert.True(response);
        }

        [Fact]
        [UnitTest]

        public void GetAllArea()
        {
            var areaRepoMock = new Mock<IAreaRepositorio>();
            areaRepoMock
                .Setup(g => g.GetAll<AreaEntity>())
                .Returns(new List<AreaEntity>(){ new AreaEntity {
                    ResponsableEmployedId = Guid.NewGuid(),
                    AreaId = Guid.Parse("ee98a9db-1443-4491-b470-cca353138808"),
                    AreaName = "Área1"
                }});

            var service = new ServiceCollection();
            service.AddTransient(_ => areaRepoMock.Object);
            service.ConfigureAdministrationService(new DbSettings());
            var provider = service.BuildServiceProvider();
            var areaGetAllService = provider.GetRequiredService<IAreaService>();

            var response = areaGetAllService.GetAllAreaDto();
            areaRepoMock.Verify(v => v.GetAll<AreaEntity>(), Times.Once);
        }

    }
}
