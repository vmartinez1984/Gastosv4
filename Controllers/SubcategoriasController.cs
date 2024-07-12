using gastosv4.Dtos;
using gastosv4.ReglasDeNegocio;
using Microsoft.AspNetCore.Mvc;

namespace gastosv4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubcategoriasController : ControllerBase
    {
        public readonly UnitOfWork _unitOfWork;

        public SubcategoriasController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult> ObtenerTodosAsync()
        {
            List<SubcategoriaDto> subcategorias;

            subcategorias = await _unitOfWork.Subcategoria.ObtenerTodosAsync();

            return Ok(subcategorias);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> ObtenerAsync(string id)
        {
            SubcategoriaDto subcategoria;

            subcategoria = await _unitOfWork.Subcategoria.ObtenerAsync(id);
            if (subcategoria is null)
                return NotFound(new { Mensaje = "Registro no encontrado" });

            return Ok(subcategoria);
        }
    }
}