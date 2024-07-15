using gastosv4.Dtos;
using gastosv4.ReglasDeNegocio;
using Microsoft.AspNetCore.Mvc;

namespace gastosv4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        public readonly UnitOfWork _unitOfWork;

        public CategoriasController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Obtener()
        {
            List<CategoriaDto> lista;

            lista = await _unitOfWork.Categoria.ObtenerAsync();

            return Ok(lista);
        }        
    }
}