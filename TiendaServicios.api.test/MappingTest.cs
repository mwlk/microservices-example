using AutoMapper;
using TiendaServicios.api.book.Application.DTO;
using TiendaServicios.api.book.Models;

namespace TiendaServicios.api.test
{
    public class MappingTest : Profile
    {
        public MappingTest()
        {
            CreateMap<Library, LibraryDto>();
        }
    }
}
