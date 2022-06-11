using AutoMapper;
using GenFu;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TiendaServicios.api.book.Application;
using TiendaServicios.api.book.Models;
using TiendaServicios.api.book.Persistence;
using Xunit;

namespace TiendaServicios.api.test
{
    public class LibrosServiceTest
    {

        private IEnumerable<Library> GetTestData()
        {
            A.Configure<Library>()
                .Fill(x => x.Title).AsArticleTitle()
                .Fill(x => x.LibraryId, () => { return Guid.NewGuid(); });

            var lista = A.ListOf<Library>(50);
            lista[0].LibraryId = Guid.Empty;

            return lista;
        }

        private Mock<LibraryContext> BuildContext()
        {
            var testData = GetTestData().AsQueryable();

            var dbSet = new Mock<DbSet<Library>>();
            dbSet.As<IQueryable<Library>>().Setup(x => x.Provider).Returns(testData.Provider);
            dbSet.As<IQueryable<Library>>().Setup(x => x.Expression).Returns(testData.Expression);
            dbSet.As<IQueryable<Library>>().Setup(x => x.ElementType).Returns(testData.ElementType);
            dbSet.As<IQueryable<Library>>().Setup(x => x.GetEnumerator()).Returns(testData.GetEnumerator());


            dbSet.As<IAsyncEnumerable<Library>>().Setup(x => x.GetAsyncEnumerator(new CancellationToken()))
                                                 .Returns(new AsyncEnumerator<Library>(testData.GetEnumerator()));

            var context = new Mock<LibraryContext>();
            context.Setup(x => x.Libreria).Returns(dbSet.Object);

            return context;
        }

        [Fact]
        public async void GetLibros()
        {
            System.Diagnostics.Debugger.Launch();


            var mockContext = BuildContext();
            var mapConfig = new MapperConfiguration(config =>
            {
                config.AddProfile(new MappingTest());
            });

            var mockMapper = mapConfig.CreateMapper();

            Search.Manejador manejador = new Search.Manejador(mockContext.Object, mockMapper);

            Search.Ejecuta request = new Search.Ejecuta();

            var listado = await manejador.Handle(request, new CancellationToken());

            Assert.True(listado.Any());
        }
    }
}
