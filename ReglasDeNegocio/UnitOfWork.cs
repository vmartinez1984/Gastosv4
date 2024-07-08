using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gastosv4.ReglasDeNegocio
{
    public class UnitOfWork
    {
        public UnitOfWork(
            SubcategoriaRdN subcategoriaBl,
            CategoriaRdN categoriaBl
            // CuentaBl cuentaBl,
            // TransaccionBl transaccionBl,
            // HistorialBl historialBl,
            // VersionBl versionBl,
            // PresupuestoBl presupuestoBl,
            // TipoDeCuentaBl tipoDeCuentaBl,
            // PeriodoBl periodoBl,
            // MovimientoBl movimientoBl
        )
        {
            Categoria = categoriaBl;
            Subcategoria = subcategoriaBl;
            // Cuenta = cuentaBl;
            // Transaccion = transaccionBl;
            // Historial = historialBl;
            // Version = versionBl;
            // Presupuesto = presupuestoBl;
            // TipoDeCuenta = tipoDeCuentaBl;
            // Periodo = periodoBl;
            // Movimiento = movimientoBl;
        }
        public SubcategoriaRdN Subcategoria { get; internal set; }
        public CategoriaRdN Categoria { get; set; }

        // public CuentaBl Cuenta { get; }
        // public TransaccionBl Transaccion { get; }
        // public HistorialBl Historial { get; internal set; }
        // public VersionBl Version { get; set; }
        // public PresupuestoBl Presupuesto { get; internal set; }
        // public TipoDeCuentaBl TipoDeCuenta { get; internal set; }
        // public PeriodoBl Periodo { get; internal set; }
        // public MovimientoBl Movimiento { get; internal set; }
    }

}