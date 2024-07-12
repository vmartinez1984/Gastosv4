using AutoMapper;
using gastosv4.Dtos;
using gastosv4.Entidades;
using gastosv4.Repositorios;

namespace gastosv4.ReglasDeNegocio
{
    public class SubcategoriaRdN
    {
        private readonly Repositorio _repositorio;
        private readonly IMapper _mapper;

        public SubcategoriaRdN(Repositorio repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<List<SubcategoriaDto>> ObtenerTodosAsync()
        {
            List<SubcategoriaDto> lista;
            List<Subcategoria> entidades;

            entidades = await _repositorio.Subcategoria.ObtenerTodosAsync();
            lista = _mapper.Map<List<SubcategoriaDto>>(entidades);
            
            return lista;
        }

        internal async Task<SubcategoriaDto> ObtenerAsync(string id)
        {
            SubcategoriaDto dto;
            Subcategoria entidad;

            entidad = await _repositorio.Subcategoria.ObtenerAsync(id);
            dto = _mapper.Map<SubcategoriaDto>(entidad);

            return dto;
        }
    }
}