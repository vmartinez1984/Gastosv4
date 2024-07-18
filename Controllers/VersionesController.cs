using gastosv4.ReglasDeNegocio;
using Gastosv4.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Gastosv4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VersionesController : ControllerBase
    {
        public readonly UnitOfWork _unitOfWork;

        public VersionesController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> AgregarAsync(VersionDtoIn version)
        {
            string id;

            id = await _unitOfWork.Version.AgregarAsync(version);

            return Ok(new { Id = id });
        }

        [HttpPost("{id}/Detalles")]
        public async Task<IActionResult> AgregarDetalleAsync(string id, DetalleDto detalle)
        {
            await _unitOfWork.Version.AgregarDetalleAsync(id, detalle);

            return Ok(new { Guid = detalle.Guid });
        }

        [HttpPut("{id}/Detalles")]
        public async Task<IActionResult> ActualizarDetalleAsync(string id, DetalleDto detalle)
        {
            await _unitOfWork.Version.ActualizarDetalleAsync(id, detalle);

            return Ok(new { Guid = detalle.Guid });
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerAsync()
        {
            List<VersionDto> lista;

            lista = await _unitOfWork.Version.ObtenerAsync();

            return Ok(lista);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorIdAsync(string id)
        {
            VersionDto dto;

            dto = await _unitOfWork.Version.ObtenerAsync(id);

            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarAsync(string id, VersionDtoIn dto)
        {
            await _unitOfWork.Version.ActualizarAsync(id, dto);

            return Accepted();
        }
    }
}