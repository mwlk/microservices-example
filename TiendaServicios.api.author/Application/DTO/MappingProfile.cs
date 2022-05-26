using AutoMapper;
using TiendaServicios.api.author.Models;

namespace TiendaServicios.api.author.Application.DTO
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Author, AuthorDTO>();
        }
    }
}
