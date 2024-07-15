using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            VersionRdN versionBl
            // PresupuestoBl presupuestoBl,
            // TipoDeCuentaBl tipoDeCuentaBl,
            // PeriodoBl periodoBl,
            // MovimientoBl movimientoBl
        )
        {
            Categoria = categoriaBl;
            Subcategoria = subcategoriaBl;
            Version = versionBl;
            Ahorro = ahorroRdN;
            // Transaccion = transaccionBl;
            // Historial = historialBl;
            // Presupuesto = presupuestoBl;
            // TipoDeCuenta = tipoDeCuentaBl;
            // Periodo = periodoBl;
            // Movimiento = movimientoBl;
        }
        public SubcategoriaRdN Subcategoria { get; internal set; }
        public CategoriaRdN Categoria { get; set; }

        public VersionRdN Version { get; set; }
        
        public AhorroRdN Ahorro {get; set;}
        // public TransaccionBl Transaccion { get; }
        // public HistorialBl Historial { get; internal set; }
        // public PresupuestoBl Presupuesto { get; internal set; }
        // public TipoDeCuentaBl TipoDeCuenta { get; internal set; }
        // public PeriodoBl Periodo { get; internal set; }
        // public MovimientoBl Movimiento { get; internal set; }
    }

}