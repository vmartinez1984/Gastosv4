using System.ComponentModel.DataAnnotations;

namespace Gastosv4.Dtos
{
    public class MovimientoPeriodoDtoIn
    {        
        //public string Guid { get; set; }
        [Required]
        public string DetalleId {get; set;}

        [Required]
        [Range(1,34000)]
        public decimal Cantidad{get; set;}

        public string Nota{get; set;}
    }
}