using System.ComponentModel.DataAnnotations;

namespace Gastosv4.Dtos
{
    public class PeriodoDtoIn
    {
        [Required]
        public string VersionId { get; set; }

        public string Guid { get; set; }

        [Required]
        public string Nombre { get; set; }

        public DateTime FechaInicial { get; set; }

        public DateTime FechaFinal { get; set; } 
    }

    public class PeriodoDto
    {
        public int Id { get; set; }
        
        public string VersionId { get; set; }

        public string Guid { get; set; }
        
        public string Nombre { get; set; }

        public DateTime FechaInicial { get; set; }

        public DateTime FechaFinal { get; set; } 

        public List<DetalleDePeriodoDto> Detalles { get; set; }
    }

    public class DetalleDePeriodoDto
    {
        public DetalleDto Detalle{ get; set; }

        public List<MovimientoPeriodoDto> Movimientos { get; set; } = new List<MovimientoPeriodoDto>();
    }

    public class MovimientoPeriodoDto
    {
        public decimal Cantidad { get; set; }

        public string Guid { get; set; }

        public string Nota { get; set; }
    }
}