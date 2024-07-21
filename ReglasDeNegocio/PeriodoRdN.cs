using AutoMapper;
using gastosv4.Repositorios;
using Gastosv4.Dtos;
using Gastosv4.Entidades;
using Gastosv4.services;

namespace Gastosv4.ReglasDeNegocio
{
    public class PeriodoRdN
    {
        private readonly Repositorio _repositorio;
        private readonly DuckBankServicio _bankServicio;
        private readonly IMapper _mapper;

        public PeriodoRdN(Repositorio repositorio, DuckBankServicio bankServicio, IMapper mapper)
        {
            _repositorio = repositorio;
            _bankServicio = bankServicio;
            _mapper = mapper;
        }

        public async Task<string> AgregarAsync(PeriodoDtoIn dto)
        {
            VersionDePeriodo version;
            Periodo periodo;

            version = await _repositorio.Version.ObtenerAsync(dto.VersionId);
            periodo = new Periodo
            {
                EstaActivo = true,
                FechaFinal = dto.FechaFinal,
                FechaInicial = dto.FechaInicial,
                Nombre = dto.Nombre,
                Version = version,
                Detalles = ObterDetalles(version),
                Guid = string.IsNullOrEmpty(dto.Guid) ? Guid.NewGuid().ToString() : dto.Guid,
            };

            periodo.Id = await _repositorio.Periodo.AgregarAsync(periodo);

            return periodo.Id;
        }

        private List<DetalleDePeriodo> ObterDetalles(VersionDePeriodo version)
        {
            List<DetalleDePeriodo> detalleDePeriodos;

            detalleDePeriodos = new List<DetalleDePeriodo>();
            version.Detalles.ForEach(x =>
            {
                detalleDePeriodos.Add(new DetalleDePeriodo
                {
                    Detalle = x
                });
            });

            return detalleDePeriodos;
        }

        public async Task<string> AgregarMovimientoDelPeriodo(string peridoId, MovimientoPeriodoDtoIn moviento)
        {
            Periodo periodo;
            string referencia;

            referencia = Guid.NewGuid().ToString();
            periodo = await _repositorio.Periodo.ObtenerAsync(peridoId);
            var detalle = periodo.Detalles.Where(x => x.Detalle.Guid == moviento.DetalleId).FirstOrDefault();
            detalle.Movimientos.Add(new MovimientoPeriodo
            {
                Cantidad = moviento.Cantidad,
                Guid = referencia,
                Nota = moviento.Nota
            });
            await _bankServicio.DepositarAsync(detalle.Detalle.AhorroId, new Movimiento
            {
                Cantidad = moviento.Cantidad,
                Concepto = detalle.Detalle.Nombre,
                FechaDeRegistro = DateTime.Now,
                Referencia = referencia
            });
            await _repositorio.Periodo.ActualizarAsync(periodo);

            return referencia;
        }

        public async Task<List<PeriodoDto>> ObtenerAsync()
        {
            List<PeriodoDto> dtos;
            List<Periodo> entidades;

            entidades = await _repositorio.Periodo.ObtenerAsync();
            dtos = _mapper.Map<List<PeriodoDto>>(entidades);

            return dtos;
        }

        public async Task<PeriodoDto> ObtenerAsync(string id)
        {
            PeriodoDto dto;
            Periodo entidad;

            entidad = await _repositorio.Periodo.ObtenerAsync(id);
            dto = _mapper.Map<PeriodoDto>(entidad);

            return dto;
        }
    }
}