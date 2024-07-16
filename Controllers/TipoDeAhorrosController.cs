using gastosv4.ReglasDeNegocio;
using Gastosv4.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Gastosv4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoDeAhorrosController : ControllerBase
    {
        public readonly UnitOfWork _unitOfWork;

        public TipoDeAhorrosController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult> ObtenerTodosAsync()
        {
            List<TipoDeAhorroDto> lista;

            lista = await _unitOfWork.TipoDeAhorro.ObtenerTodosAsync();

            return Ok(lista);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> ObtenerAsync(string id)
        {
            TipoDeAhorroDto dto;

            dto = await _unitOfWork.TipoDeAhorro.ObtenerAsync(id);
            if (dto is null)
                return NotFound(new { Mensaje = "Registro no encontrado" });

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> AgregarAsync(TipoDeAhorroDtoIn item)
        {
            string id;

            id = await _unitOfWork.TipoDeAhorro.AgregarAsync(item);

            return Ok(new { Id = id });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> ActualizarAsync(string id, TipoDeAhorroDtoIn item)
        {
            await _unitOfWork.TipoDeAhorro.ActualizarAsync(id, item);

            return Accepted();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> BorrarAsync(string id)
        {
            await _unitOfWork.TipoDeAhorro.BorrarAsync(id);

            return Accepted();
        }
    }
}