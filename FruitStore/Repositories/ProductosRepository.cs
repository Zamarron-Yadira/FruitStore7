using FruitStore.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FruitStore.Repositories
{
    public class ProductosRepository:Repository<Productos>
    {
        public ProductosRepository(FruteriashopContext context):base(context)
        {
                
        }
        public IEnumerable<Productos> GetProductosByCategorias(string categoria)
        {
            return Context.Productos.
                Include(x=>x.IdCategoriaNavigation)
                .Where(x => x.IdCategoriaNavigation !=null && x.IdCategoriaNavigation.Nombre == categoria).
                OrderBy(x=>x.Nombre);
        }

        public Productos? GetByNombre(string nombre)
        {
            return Context.Productos.Include(x => x.IdCategoriaNavigation).FirstOrDefault(x => x.Nombre == nombre);
        }
    }
}
