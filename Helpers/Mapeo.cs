using AutoMapper;
using gastosv4.Dtos;
using gastosv4.Entidades;

namespace gastosv4.Helpers
{
    public class Mapeo: Profile
    {
        public Mapeo()
        {
            CreateMap<Categoria, CategoriaDto>();
        }
    }
}