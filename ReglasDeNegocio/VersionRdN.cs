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

        public async Task<List<VersionDto>> ObtenerAsync()
        {
            List<VersionDto> dtos;
            List<VersionDePeriodo> entidades;

            entidades = await _repositorio.Version.ObtenerTodosAsync();
            dtos = _mapper.Map<List<VersionDto>>(entidades);

            return dtos;
        }

        public async Task<VersionDto> ObtenerAsync(string id)
        {
            VersionDto dto;
            VersionDePeriodo entidad;

            entidad = await _repositorio.Version.ObtenerAsync(id);
            dto = _mapper.Map<VersionDto>(entidad);

            return dto;
        }

        internal async Task ActualizarAsync(string id, VersionDtoIn dto)
        {
            VersionDePeriodo entidad;

            entidad = await _repositorio.Version.ObtenerAsync(id);
            entidad.Nombre = dto.Nombre;
            entidad.FechaFinal = dto.FechaFinal;
            entidad.FechaInicial = dto.FechaInicial;

            await _repositorio.Version.ActualizarAsync(entidad);
        }

        internal async Task ActualizarDetalleAsync(string id, DetalleDto detalle)
        {
            VersionDePeriodo entitdad;
            Detalle detalle1;

            entitdad = await _repositorio.Version.ObtenerAsync(id);
            detalle1 = entitdad.Detalles.FirstOrDefault(x => x.Guid == detalle.Guid);
            detalle1.AhorroId = detalle.AhorroId;
            detalle1.Cantidad = detalle.Cantidad;
            detalle1.Nombre = detalle.Nombre;

            await _repositorio.Version.ActualizarAsync(entitdad);
        }
    }
}