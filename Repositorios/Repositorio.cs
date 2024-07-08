namespace gastosv4.Repositorios
{
    public class Repositorio
    {
        public SubcategoriaRepositorio Subcategoria {get;}

        public CategoriaRepositorio Categoria { get; }
        
        public Repositorio(
            CategoriaRepositorio categoriaRepositorio,
            SubcategoriaRepositorio subcategoriaRepositorio
        )
        {
            Categoria = categoriaRepositorio;
            Subcategoria = subcategoriaRepositorio;
        }

    }
}