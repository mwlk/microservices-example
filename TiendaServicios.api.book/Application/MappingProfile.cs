using AutoMapper;
using TiendaServicios.api.book.Application.DTO;
using TiendaServicios.api.book.Models;

namespace TiendaServicios.api.book.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Library, LibraryDto>();
        }
    }
}
