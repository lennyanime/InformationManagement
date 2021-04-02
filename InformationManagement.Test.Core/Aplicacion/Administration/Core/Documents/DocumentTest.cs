using GestionInformacion.Infraestructura.Datos.Persistencia.Core.Base.Configuration;
using InformationManagement.Aplication.Core.Administration.Administration.Configurator;
using InformationManagement.Aplication.Core.Administration.Documents.Services;
using InformationManagement.Aplication.Dto.Administration.Documents;
using InformationManagement.Dominio.Core.Administracion.Documento;
using InformationManagement.Dominio.Core.Administration.Document;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;
using Xunit.Categories;

namespace InformationManagement.Test.Core.Aplicacion.Administration.Core.Documents
{

    public class DocumentTest
    {
        [Fact]
        [UnitTest]
        public async Task Document_Not_Null()
        {
            var service = new ServiceCollection();
            service.ConfigureAdministrationService(new DbSettings());
            var provider = service.BuildServiceProvider();
            var documentService = provider.GetRequiredService<IDocumentService>();

            await Assert.ThrowsAsync<ArgumentNullException>(() => documentService.AddDocument(null)).ConfigureAwait(false);
            await Assert.ThrowsAsync<ArgumentNullException>(() => documentService.DeleteDocument(null)).ConfigureAwait(false);
            await Assert.ThrowsAsync<ArgumentNullException>(() => documentService.UpdateDocument(null)).ConfigureAwait(false);
            await Assert.ThrowsAsync<ArgumentNullException>(() => documentService.SearchDocumentById(null)).ConfigureAwait(false);
        }

        [Fact]
        [UnitTest]

        public async Task Add_Document()
        {
            var documentRepoMock = new Mock<IDocumentTypeRepositorio>();
            documentRepoMock
                .Setup(e => e.SearchMatching(It.IsAny<Expression<Func<DocumentTypeEntity, bool>>>()))
                .Returns(new List<DocumentTypeEntity>());

            var service = new ServiceCollection();
            service.AddTransient(_ => documentRepoMock.Object);
            service.ConfigureAdministrationService(new DbSettings());
            var provider = service.BuildServiceProvider();
            var areaService = provider.GetRequiredService<IDocumentService>();

            var response = await areaService.AddDocument(new DocumentDto
            {

                TypeIdentificationId = Guid.Parse("b554aa99-203f-4930-8b4c-ecd51affef56"),
                //IdentificationName = TypeDocument.cedula

            });
        }

        [Fact]
        [UnitTest]
        public async Task Delete_Document()
        {
            var documentRepoMock = new Mock<IDocumentTypeRepositorio>();
            documentRepoMock
                .Setup(d => d.SearchMatching(It.IsAny<Expression<Func<DocumentTypeEntity, bool>>>()))
                .Returns(new List<DocumentTypeEntity>() { new DocumentTypeEntity{

                    TypeIdentificationId = Guid.Parse("94977d67-e18d-45d8-b5d4-e715e9972cef"),
                    IdentificationName = "Cédula"
                }});

            documentRepoMock
                .Setup(d => d.Delete(It.IsAny<DocumentTypeEntity>()))
                .Returns(true);

            var service = new ServiceCollection();
            service.AddTransient(_ => documentRepoMock.Object);
            service.ConfigureAdministrationService(new DbSettings());
            var provider = service.BuildServiceProvider();
            var documentDeleteService = provider.GetRequiredService<IDocumentService>();

            var document = new DocumentDto
            {
                TypeIdentificationId = Guid.Parse("94977d67-e18d-45d8-b5d4-e715e9972cef"),
                IdentificationName = "Cédula"
            };

            var response = await documentDeleteService.DeleteDocument(document).ConfigureAwait(false);
            documentRepoMock.Verify(d => d.Delete(It.IsAny<DocumentTypeEntity>()), Times.Once);
            Assert.True(response);
        }

        [Fact]
        [UnitTest]
        public async Task Update_Document()
        {
            var documentRepoMock = new Mock<IDocumentTypeRepositorio>();
            documentRepoMock
                .Setup(id => id.SearchMatching(It.IsAny<Expression<Func<DocumentTypeEntity, bool>>>()))
                .Returns(new List<DocumentTypeEntity> { new DocumentTypeEntity
                {

                   TypeIdentificationId = Guid.Parse("d6e937b2-9966-418e-a022-b342ebfeb09a"),
                   IdentificationName = "Cédula"

                }});

            documentRepoMock
                .Setup(d => d.Update(It.IsAny<DocumentTypeEntity>()))
                .Returns(true);

            var service = new ServiceCollection();
            service.AddTransient(_ => documentRepoMock.Object);
            service.ConfigureAdministrationService(new DbSettings());
            var provider = service.BuildServiceProvider();
            var areaUpdateService = provider.GetRequiredService<IDocumentService>();

            var document = new DocumentDto
            {
                TypeIdentificationId = Guid.Parse("d6e937b2-9966-418e-a022-b342ebfeb09a"),
                IdentificationName = "Cédula"
            };

            var response = await areaUpdateService.UpdateDocument(document).ConfigureAwait(false);
            Assert.True(response);
        }

        [Fact]
        [UnitTest]

        public void GetAllDocument()
        {
            var documentRepoMock = new Mock<IDocumentTypeRepositorio>();
            documentRepoMock
                .Setup(g => g.GetAll<DocumentTypeEntity>())
                .Returns(new List<DocumentTypeEntity>(){ new DocumentTypeEntity {

                }});

            var service = new ServiceCollection();
            service.AddTransient(_ => documentRepoMock.Object);
            service.ConfigureAdministrationService(new DbSettings());
            var provider = service.BuildServiceProvider();
            var areaGetAllService = provider.GetRequiredService<IDocumentService>();

            var response = areaGetAllService.GetAllDocuments();
            documentRepoMock.Verify(v => v.GetAll<DocumentTypeEntity>(), Times.Once);
        }

        [Fact]
        [UnitTest]

        public async Task Searching_Document_By_Id()
        {
            var documentRepoMock = new Mock<IDocumentTypeRepositorio>();
            documentRepoMock
                .Setup(id => id.SearchMatching(It.IsAny<Expression<Func<DocumentTypeEntity, bool>>>()))
                .Returns(new List<DocumentTypeEntity>() { new DocumentTypeEntity{

                    TypeIdentificationId = Guid.Parse("d6e937b2-9966-418e-a022-b342ebfeb09a"),
                    IdentificationName = "Cédula"
                }});

            var service = new ServiceCollection();
            service.AddTransient(_ => documentRepoMock.Object);
            service.ConfigureAdministrationService(new DbSettings());
            var provider = service.BuildServiceProvider();
            var documentIdService = provider.GetRequiredService<IDocumentService>();

            var document = new DocumentDto
            {
                TypeIdentificationId = Guid.Parse("d6e937b2-9966-418e-a022-b342ebfeb09a"),
                IdentificationName = "Cédula"
            };

            var response = await documentIdService.SearchDocumentById(document).ConfigureAwait(false);

            Assert.Equal(document.TypeIdentificationId, response.TypeIdentificationId);
        }
    }
}
