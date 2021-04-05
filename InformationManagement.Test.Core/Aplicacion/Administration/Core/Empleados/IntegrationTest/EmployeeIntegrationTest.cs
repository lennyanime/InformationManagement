using AutoMapper;
using GestionInformacion.Infraestructura.Datos.Persistencia.Core.Base.Configuration;
using InformationManagement.Aplication.Core.Administration.Administration.Configurator;
using InformationManagement.Aplication.Core.Administration.Areas;
using InformationManagement.Aplication.Core.Administration.Documents.Services;
using InformationManagement.Aplication.Core.Administration.Employees.Services;
using InformationManagement.Aplication.Dto.Administration;
using InformationManagement.Aplication.Dto.Administration.Areas;
using InformationManagement.Aplication.Dto.Administration.Documents;
using InformationManagement.Aplication.Dto.Administration.Employees;
using InformationManagement.Dominio.Core.Administracion.Documento;
using InformationManagement.Dominio.Core.Administration.Areas;
using InformationManagement.Dominio.Core.Administration.Document;
using InformationManagement.Dominio.Core.Areas;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Categories;

namespace InformationManagement.Test.Core.Aplicacion.Administration.Core.Empleados.IntegrationTest
{
    public class EmployeeIntegrationTest
    {
        [Fact]
        [IntegrationTest]

        public async Task Employee_With_The_Same_Code_And_Id_Is_Not_Permitted_Integration_Test() 
        {
            var service = new ServiceCollection();
            service.ConfigureAdministrationService(new DbSettings 
            { 
                ConnectionString = "Server=HERMANITOS; Database=InformationManagement;Trusted_Connection=True;"
            });
            var provider = service.BuildServiceProvider();
            var employeeService = provider.GetRequiredService<IEmployeeService>();
            //área
            var areaService = provider.GetRequiredService<IAreaService>();
            var areaRepositorio = provider.GetRequiredService<IAreaRepositorio>();

            var documentService = provider.GetRequiredService<IDocumentService>();
            var documentRepositorio = provider.GetRequiredService<IDocumentTypeRepositorio>();

            var mapper = provider.GetRequiredService<IMapper>();
            

            var dtoArea = new AreaDto
            {
                AreaId = Guid.Parse("11111111-5717-4562-b3fc-2c963f66afa1"),
                AreaName = "FakeArea1",
                ResponsableEmployedId = Guid.NewGuid()
            };
            var area = areaRepositorio
                .SearchMatching<AreaEntity>(x => x.AreaName == dtoArea.AreaName)
                .FirstOrDefault();
            if (area != null || area != default)
                areaRepositorio.Delete(area);
            var guidArea = await areaService.AddArea(dtoArea).ConfigureAwait(false);


            var typeDocument = new DocumentDto
            {
                IdentificationName = "Cédula",
                TypeIdentificationId = Guid.Parse("77777777-5717-4562-b3fc-2c963f66afa1"),
                //TypeDocument = TypeDocument.Cedula
            };
            var document = documentRepositorio
                .SearchMatching<DocumentTypeEntity>(x => x.TypeIdentificationId == typeDocument.TypeIdentificationId)
                .FirstOrDefault();
            if (document != null || document != default)
                documentRepositorio.Delete(document);
            var guidDocument = await documentService.AddDocument(typeDocument).ConfigureAwait(false);

            var response = new EmployeeDto
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
                DateOfBirth = DateTimeOffset.Parse("28-05-1991"),
                SignUpDate = DateTimeOffset.Parse("12-02-2021"),
                AreaId = Guid.Parse("11111111-5717-4562-b3fc-2c963f66afa1"),
                DocumentNumber = 12345,
                DocumentTypeId = Guid.Parse("77777777-5717-4562-b3fc-2c963f66afa1"),
                TypeDocument = Type_Document.Cedula
            };

            var request = await employeeService.AddEmployee(response).ConfigureAwait(false);

            Assert.Equal(response.EmployeeId , request.EmployeeId);

            //_ = employeeService.DeleteEmploye(response);
            //var areaEnd = areaRepositorio
            //    .SearchMatching<AreaEntity>(x => x.AreaName == dtoArea.AreaName || x.AreaId == dtoArea.AreaId)
            //    .FirstOrDefault();
            //areaRepositorio.Delete(areaEnd);

            //var documentDelete = documentRepositorio
            //   .SearchMatching<DocumentTypeEntity>(x => x.TypeIdentificationId == typeDocument.TypeIdentificationId)
            //   .FirstOrDefault();
            //documentRepositorio.Delete(documentDelete);


        }
    }
}
