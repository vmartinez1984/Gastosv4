using gastosv4.ReglasDeNegocio;
using Gastosv4.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Gastosv4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeriodosController : ControllerBase
    {
        public readonly UnitOfWork _unitOfWork;

        public PeriodosController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerAsync()
        {
            List<PeriodoDto> dtos = await _unitOfWork.Periodo.ObtenerAsync();

            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerAsync(string id)
        {
            PeriodoDto dto = await _unitOfWork.Periodo.ObtenerAsync(id);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> AgregarAsync(PeriodoDtoIn dto)
        {
            string id;

            id = await _unitOfWork.Periodo.AgregarAsync(dto);

            return Ok(new { Id = id });
        }

        [HttpPost("{id}/Movimientos")]
        public async Task<IActionResult> AgregarMovimientoAsync(string id, MovimientoPeriodoDtoIn movimiento)
        {
            string data =

            await _unitOfWork.Periodo.AgregarMovimientoDelPeriodo(id, movimiento);

            return Ok(new { Guid = data});
        }
    }
}