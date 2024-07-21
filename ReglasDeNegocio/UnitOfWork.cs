using Gastosv4.ReglasDeNegocio;

namespace gastosv4.ReglasDeNegocio
{
    public class UnitOfWork
    {
        public UnitOfWork(
            SubcategoriaRdN subcategoriaBl,
            CategoriaRdN categoriaBl,
            AhorroRdN ahorroRdN,
            VersionRdN versionBl,
            TipoDeAhorroRdN tipoDeAhorroRdN,
            PeriodoRdN periodoRdN
            // TransaccionBl transaccionBl,
            // HistorialBl historialBl,
            // PresupuestoBl presupuestoBl,
            // MovimientoBl movimientoBl
        )
        {
            Categoria = categoriaBl;
            Subcategoria = subcategoriaBl;
            Version = versionBl;
            Ahorro = ahorroRdN;
            TipoDeAhorro = tipoDeAhorroRdN;
            Periodo = periodoRdN;
            // Transaccion = transaccionBl;
            // Historial = historialBl;
            // Presupuesto = presupuestoBl;            
            // Movimiento = movimientoBl;
        }
        public PeriodoRdN Periodo {get;}

        public SubcategoriaRdN Subcategoria { get; }

        public CategoriaRdN Categoria { get; }

        public VersionRdN Version { get;  }
        
        public AhorroRdN Ahorro {get; }
        // public TransaccionBl Transaccion { get; }
        // public HistorialBl Historial { get; internal set; }
        // public PresupuestoBl Presupuesto { get; internal set; }
        public TipoDeAhorroRdN TipoDeAhorro{get;}
 
        // public MovimientoBl Movimiento { get; internal set; }
    }

}