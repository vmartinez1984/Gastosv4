using AutoMapper;
using gastosv4.Dtos;
using gastosv4.Entidades;
using gastosv4.Repositorios;

namespace gastosv4.ReglasDeNegocio
{
    public class CategoriaRdN
    {
        private readonly Repositorio _repositorio;
        private readonly IMapper _mapper;

        public CategoriaRdN(Repositorio repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }
        
        public async Task<List<CategoriaDto>> ObtenerAsync()
        {
            List<Categoria> categorias;
            List<CategoriaDto> categoriasDto;

            categorias = await _repositorio.Categoria.ObtenerTodosAsync();
            categoriasDto = _mapper.Map<List<CategoriaDto>>(categorias);

            return categoriasDto;
        }
    }
}