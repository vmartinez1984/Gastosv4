using Gastosv4.ReglasDeNegocio;

namespace gastosv4.ReglasDeNegocio
{
    public class UnitOfWork
    {
        public UnitOfWork(
            SubcategoriaRdN subcategoriaBl,
            CategoriaRdN categoriaBl,
            AhorroRdN ahorroRdN,
            // TransaccionBl transaccionBl,
            // HistorialBl historialBl,
            VersionRdN versionBl,
            // PresupuestoBl presupuestoBl,
            TipoDeAhorroRdN tipoDeAhorroRdN
            // PeriodoBl periodoBl,
            // MovimientoBl movimientoBl
        )
        {
            Categoria = categoriaBl;
            Subcategoria = subcategoriaBl;
            Version = versionBl;
            Ahorro = ahorroRdN;
            TipoDeAhorro = tipoDeAhorroRdN;
            // Transaccion = transaccionBl;
            // Historial = historialBl;
            // Presupuesto = presupuestoBl;
            // Periodo = periodoBl;
            // Movimiento = movimientoBl;
        }
        public SubcategoriaRdN Subcategoria { get; }

        public CategoriaRdN Categoria { get; }

        public VersionRdN Version { get;  }
        
        public AhorroRdN Ahorro {get; }
        // public TransaccionBl Transaccion { get; }
        // public HistorialBl Historial { get; internal set; }
        // public PresupuestoBl Presupuesto { get; internal set; }
        public TipoDeAhorroRdN TipoDeAhorro{get;}
        // public PeriodoBl Periodo { get; internal set; }
        // public MovimientoBl Movimiento { get; internal set; }
    }

}