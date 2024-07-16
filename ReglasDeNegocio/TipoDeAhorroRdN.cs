using AutoMapper;
using gastosv4.Repositorios;
using Gastosv4.Dtos;
using Gastosv4.Entidades;

namespace Gastosv4.ReglasDeNegocio
{
    public class TipoDeAhorroRdN
    {
        private readonly Repositorio _repositorio;
        private readonly IMapper _mapper;

        public TipoDeAhorroRdN(Repositorio repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<List<TipoDeAhorroDto>> ObtenerTodosAsync()
        {
            List<TipoDeAhorroDto> lista;
            List<TipoDeAhorro> entidades;

            entidades = await _repositorio.TipoDeAhorro.ObtenerTodosAsync();
            lista = _mapper.Map<List<TipoDeAhorroDto>>(entidades);
            
            return lista;
        }

        public async Task<string> AgregarAsync(TipoDeAhorroDtoIn item)
        {
            string id;
            TipoDeAhorro entidad;

            entidad = _mapper.Map<TipoDeAhorro>(item);
            id = await _repositorio.TipoDeAhorro.AgregarAsync(entidad);

            return id;
        }

        public async Task<TipoDeAhorroDto> ObtenerAsync(string id)
        {
            TipoDeAhorroDto dto;
            TipoDeAhorro entidad;

            entidad = await _repositorio.TipoDeAhorro.ObtenerAsync(id);
            dto = _mapper.Map<TipoDeAhorroDto>(entidad);

            return dto;
        }

        public async Task ActualizarAsync(string id, TipoDeAhorroDtoIn item)
        {
            TipoDeAhorro entidad;            

            entidad = await _repositorio.TipoDeAhorro.ObtenerAsync(id);            
            entidad.Nombre = item.Nombre;

            await _repositorio.TipoDeAhorro.ActualizarAsync(entidad);
        }

        public async Task BorrarAsync(string id)
        {           
            await _repositorio.TipoDeAhorro.BorrarAsync(id);
        }
    }
}