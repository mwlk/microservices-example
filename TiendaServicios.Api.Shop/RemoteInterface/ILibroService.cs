using System;
using System.Threading.Tasks;
using TiendaServicios.Api.Shop.RemoteModel;

namespace TiendaServicios.Api.Shop.RemoteInterface
{
    public interface ILibroService
    {
        Task<(bool result, RemoteBook book, string errorMessage)> GetLibro(Guid LibroId);
    }
}
