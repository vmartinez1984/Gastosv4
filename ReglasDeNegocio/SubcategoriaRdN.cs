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

        public async Task<string> AgregarAsync(SubcategoriaDtoIn item)
        {
            string id;
            Subcategoria subcategoria;

            subcategoria = _mapper.Map<Subcategoria>(item);
            if(string.IsNullOrEmpty( subcategoria.Guid))
                subcategoria.Guid = Guid.NewGuid().ToString();
            id = await _repositorio.Subcategoria.AgregarAsync(subcategoria);

            return id;
        }

        public async Task<SubcategoriaDto> ObtenerAsync(string id)
        {
            SubcategoriaDto dto;
            Subcategoria entidad;

            entidad = await _repositorio.Subcategoria.ObtenerAsync(id);
            dto = _mapper.Map<SubcategoriaDto>(entidad);

            return dto;
        }

        public async Task ActualizarAsync(string id, SubcategoriaDtoIn subcategoria)
        {
            Subcategoria subcategoria1;            

            subcategoria1 = await _repositorio.Subcategoria.ObtenerAsync(id);
            //subcategoria1 = _mapper.Map(subcategoria1,subcategoria);
            subcategoria1.Categoria = subcategoria.Categoria;
            subcategoria1.EsPrimario = subcategoria.EsPrimario;
            subcategoria1.Cantidad = subcategoria.Cantidad;
            subcategoria1.Nombre = subcategoria.Nombre;

            await _repositorio.Subcategoria.ActualizarAsync(subcategoria1);
        }
    }
}