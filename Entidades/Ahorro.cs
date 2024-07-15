namespace Gastosv4.Entidades
{
    public class Ahorro
    {
        public string _id { get; set; }
        public int Id { get; set; }
        public string Guid { get; set; }
        public string Nombre { get; set; }
        public decimal Total { get; set; }
        public List<Movimiento> Depositos { get; set; } = new List<Movimiento>();
        public List<Movimiento> Retiros { get; set; } = new List<Movimiento> { };
        public string ClienteId { get; set; }
        public Dictionary<string, string> Otros { get; set; } = new Dictionary<string, string>();
        public decimal Interes { get; set; }

        public DateTime FechaDeRegistro { get; set; } = DateTime.Now;

        public string Estado { get; set; }
    }

    public class Movimiento
    {
        public decimal Cantidad { get; set; }

        public DateTime FechaDeRegistro { get; set; }

        public string Concepto { get; set; }

        public string Referencia { get; set; }
    }
}