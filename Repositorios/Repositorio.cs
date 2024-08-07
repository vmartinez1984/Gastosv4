using Gastosv4.Repositorios;

namespace gastosv4.Repositorios
{
    public class Repositorio
    {
        public SubcategoriaRepositorio Subcategoria { get; }

        public CategoriaRepositorio Categoria { get; }

        public TipoDeAhorroRepositorio TipoDeAhorro { get; }

        public VersionRepositorio Version { get; }
        public PeriodoRepositorio Periodo { get; }

        public Repositorio(
            CategoriaRepositorio categoriaRepositorio,
            SubcategoriaRepositorio subcategoriaRepositorio,
            TipoDeAhorroRepositorio tipoDeAhorroRepositorio,
            VersionRepositorio versionRepositorio,
            PeriodoRepositorio periodoRepositorio
        )
        {
            Categoria = categoriaRepositorio;
            Subcategoria = subcategoriaRepositorio;
            TipoDeAhorro = tipoDeAhorroRepositorio;
            Version = versionRepositorio;
            Periodo = periodoRepositorio;
        }

    }
}