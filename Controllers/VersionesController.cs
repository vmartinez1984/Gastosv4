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
        public async Task<IActionResult> ObtenerAsync(VersionDtoIn version)
        {
            string id;

            id = await _unitOfWork.Version.AgregarAsync(version);

            return Ok(new { Id = id });
        }
    }
}