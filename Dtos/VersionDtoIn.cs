using System.ComponentModel.DataAnnotations;

namespace Gastosv4.Dtos
{
    public class VersionDtoIn
    {
        public string Guid { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        public DateTime? FechaInicial { get; set; }

        public DateTime? FechaFinal { get; set; }

        //public List<DetalleDto> Detalles { get; set; } = new List<DetalleDto>();
    }

    public class DetalleDto
    {

        public string Guid { get; set; }

        public decimal Cantidad { get; set; }

        public string Nombre { get; set; }

        public string AhorroId { get; set; }

        public string TipoDeAhorro {get; set; }
    }

    public class VersionDto
    {
        public string Id { get; set; }
        
        public string Guid { get; set; }

        public string Nombre { get; set; }

        public DateTime FechaInicial { get; set; }

        public DateTime FechaFinal { get; set; }

        public List<DetalleDto> Detalles { get; set; } = new List<DetalleDto>();
    }
}