using Amazon.Auth.AccessControlPolicy.ActionIdentifiers;
using AutoMapper;
using gastosv4.Dtos;
using gastosv4.Entidades;
using Gastosv4.Dtos;
using Gastosv4.Entidades;

namespace gastosv4.Helpers
{
    public class Mapeo : Profile
    {
        public Mapeo()
        {
            CreateMap<Categoria, CategoriaDto>();

            CreateMap<Subcategoria, SubcategoriaDto>();

            CreateMap<SubcategoriaDtoIn, Subcategoria>();

            CreateMap<Ahorro, AhorroDto>();

            CreateMap<AhorroDtoIn, Ahorro>();

            CreateMap<TipoDeAhorroDtoIn, TipoDeAhorro>();

            CreateMap<TipoDeAhorro, TipoDeAhorroDto>();

            CreateMap<VersionDtoIn, VersionDePeriodo>();

            CreateMap<VersionDePeriodo, VersionDto>();

            CreateMap<DetalleDto, Detalle>();

            CreateMap<MovimientoDtoIn, Movimiento>();

            CreateMap<Detalle, DetalleDto>();           

            CreateMap<MovimientoPeriodo, MovimientoPeriodoDto>();

            CreateMap<DetalleDePeriodo, DetalleDePeriodoDto>();          

            CreateMap<Periodo, PeriodoDto>();            
        }
    }
}