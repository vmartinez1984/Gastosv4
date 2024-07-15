using AutoMapper;
using gastosv4.Dtos;
using gastosv4.Entidades;
using Gastosv4.Dtos;
using Gastosv4.Entidades;

namespace gastosv4.Helpers
{
    public class Mapeo: Profile
    {
        public Mapeo()
        {
            CreateMap<Categoria, CategoriaDto>();

            CreateMap<Subcategoria, SubcategoriaDto>();

            CreateMap<SubcategoriaDtoIn, Subcategoria>();

            CreateMap<Ahorro, AhorroDto>();
        }
    }
}