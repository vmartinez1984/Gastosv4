using AutoMapper;
using Gastosv4.Dtos;
using Gastosv4.Entidades;
using Gastosv4.services;

namespace Gastosv4.ReglasDeNegocio
{
    public class AhorroRdN
    {
        private readonly DuckBankServicio _duckBankServicio;
        private readonly IMapper _mapper;

        public AhorroRdN(DuckBankServicio duckBankServicio, IMapper mapper)
        {
            _duckBankServicio = duckBankServicio;
            _mapper = mapper;
        }
        public async Task<List<AhorroDto>> ObtenerAsync()
        {
            List<Ahorro> ahorros;
            List<AhorroDto> dtos;

            ahorros = await _duckBankServicio.ObtenerAsync();
            dtos = _mapper.Map<List<AhorroDto>>(ahorros);

            return dtos;
        }

        public async Task<AhorroDto> ObtenerAsync(string ahorroId)
        {
            Ahorro entidad;
            AhorroDto dto;

            entidad = await _duckBankServicio.ObtenerAsync(ahorroId);
            dto = _mapper.Map<AhorroDto>(entidad);            
            dto.Depositos = dto.Depositos.OrderByDescending(a => a.FechaDeRegistro).ToList();
            dto.Retiros = dto.Retiros.OrderByDescending(a => a.FechaDeRegistro).ToList();

            return dto;
        }

        public async Task<string> AgregarAsync(AhorroDtoIn ahorro)
        {
            Ahorro ahorro1;
            int id;

            ahorro1 = _mapper.Map<Ahorro>(ahorro);
            id = await _duckBankServicio.AgregarAsycn(ahorro1);

            return id.ToString();
        }

        public async Task<string> DepositarAsync(string id, MovimientoDtoIn dto)
        {
            Movimiento entidad;

            entidad = _mapper.Map<Movimiento>(dto);
            if (string.IsNullOrEmpty(entidad.Referencia))
                entidad.Referencia = Guid.NewGuid().ToString();

            await _duckBankServicio.DepositarAsync(id, entidad);

            return entidad.Referencia;
        }

        internal async Task<string> RetirarAsync(string id, MovimientoDtoIn dto)
        {
            Movimiento entidad;

            entidad = _mapper.Map<Movimiento>(dto);
            if (string.IsNullOrEmpty(entidad.Referencia))
                entidad.Referencia = Guid.NewGuid().ToString();

            await _duckBankServicio.RetirarAsync(id, entidad);

            return entidad.Referencia;
        }
    }
}