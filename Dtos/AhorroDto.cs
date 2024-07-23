using System.ComponentModel.DataAnnotations;

namespace Gastosv4.Dtos
{
    public class AhorroDto
    {
        public int Id { get; set; }
        public string Guid { get; set; }
        public string Nombre { get; set; }
        public decimal Total { get; set; }
        public List<MovimientoDto> Depositos { get; set; } = new List<MovimientoDto>();
        public List<MovimientoDto> Retiros { get; set; } = new List<MovimientoDto> { };
        public string ClienteId { get; set; }
        public Dictionary<string, string> Otros { get; set; } = new Dictionary<string, string>();
        public decimal Interes { get; set; }

        public DateTime FechaDeRegistro { get; set; } = DateTime.Now;

        public string Estado { get; set; }
    }

    public class MovimientoDto{
        public decimal Cantidad { get; set; }        

        public string Concepto { get; set; }

        public string Referencia { get; set; }

        public DateTime FechaDeRegistro { get; set; }
    }

    public class AhorroDtoIn
    {
        public string Guid { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }
        
        [Required]
        public string ClienteId { get; set; }
        
        public Dictionary<string, string> Otros { get; set; } = new Dictionary<string, string>();

        [Range(0,20)]
        public decimal Interes { get; set; } = 0;

    }
}