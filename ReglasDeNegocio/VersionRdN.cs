using AutoMapper;
using gastosv4.Repositorios;
using Gastosv4.Dtos;
using Gastosv4.Entidades;

namespace Gastosv4.ReglasDeNegocio
{
    public class VersionRdN
    {
        private readonly Repositorio _repositorio;
        private readonly IMapper _mapper;

        public VersionRdN(Repositorio repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        // public async Task<List<VersionDto>> ObtenerTodosAsync()
        // {
        //     List<SubcategoriaDto> lista;
        //     List<Subcategoria> entidades;

        //     entidades = await _repositorio.Subcategoria.ObtenerTodosAsync();
        //     lista = _mapper.Map<List<SubcategoriaDto>>(entidades);

        //     return lista;
        // }

        public async Task<string> AgregarAsync(VersionDtoIn version)
        {
            VersionDePeriodo entidad;
            string id;

            entidad = _mapper.Map<VersionDePeriodo>(version);
            id = await _repositorio.Version.AgregarAsync(entidad);

            return id;
        }

        internal async Task AgregarDetalleAsync(string id, DetalleDto detalle)
        {
            VersionDePeriodo entitdad;
            Detalle detalle1;

            if (string.IsNullOrEmpty(detalle.Guid))
                detalle.Guid = Guid.NewGuid().ToString();
            entitdad = await _repositorio.Version.ObtenerAsync(id);
            detalle1 = _mapper.Map<Detalle>(detalle);
            entitdad.Detalles.Add(detalle1);

            await _repositorio.Version.ActualizarAsync(entitdad);
        }
    }
}