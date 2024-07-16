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

        [HttpPost]
        public async Task<IActionResult> AgregarAsync(AhorroDtoIn ahorro)
        {
            string id;

            id = await _unitOfWork.Ahorro.AgregarAsync(ahorro);

            return Ok(id);
        }
    }
}