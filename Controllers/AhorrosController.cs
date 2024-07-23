using gastosv4.ReglasDeNegocio;
using Gastosv4.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Gastosv4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AhorrosController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        public AhorrosController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerAsync()
        {
            var ahorros = await _unitOfWork.Ahorro.ObtenerAsync();

            return Ok(ahorros);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerAsync(string id)
        {
            var ahorros = await _unitOfWork.Ahorro.ObtenerAsync(id);

            return Ok(ahorros);
        }

        [HttpPost]
        public async Task<IActionResult> AgregarAsync(AhorroDtoIn ahorro)
        {
            string id;

            id = await _unitOfWork.Ahorro.AgregarAsync(ahorro);

            return Ok(id);
        }

        [HttpPost("{id}/depositos")]
        public async Task<IActionResult> Depositar(string id, MovimientoDtoIn movimiento)
        {
            movimiento.Referencia = await _unitOfWork.Ahorro.DepositarAsync(id, movimiento);

            return Created("", movimiento);
        }

        [HttpPost("{id}/retiros")]
        public async Task<IActionResult> Retiros(string id, MovimientoDtoIn movimiento)
        {
            movimiento.Referencia = await _unitOfWork.Ahorro.RetirarAsync(id, movimiento);

            return Created("", movimiento);
        }
    }
}