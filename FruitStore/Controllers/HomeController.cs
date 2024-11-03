using FruitStore.Models.Entities;
using FruitStore.Models.ViewModel;
using FruitStore.Repositories;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging;

namespace FruitStore.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(ProductosRepository repositoryProd)
        {
            Repository = repositoryProd;
        }
        public ProductosRepository Repository { get;}


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Productos(string id) /*id de categoria*/
        {
            id = id.Replace("-", " ");
            ProductosViewModel vm = new()
            {
                Categoria = id,
                Productos = Repository.GetProductosByCategorias(id).
                Select(y => new ProductosModel
                {
                    Id = y.Id,
                    NombreProd = y.Nombre ?? "",
                    Precio = y.Precio ?? 0
                })
            };
            return View(vm);
        }

        public IActionResult Ver(string id)
        {
            id = id.Replace("-"," ");
            var producto = Repository.GetByNombre(id);

            if (producto ==null)
            {
                return RedirectToAction("Index");

            }

            VerProductoViewModel vm = new()
            {
                Id = producto.Id,
                Nombre = producto.Nombre ?? "",
                Descripcion = producto.Descripcion ?? "",
                Precio = producto.Precio ?? 0,
                Categoria=producto.IdCategoriaNavigation?.Nombre ?? "",
                UnidadMedida = producto.UnidadMedida ?? ""
            };
            return View(vm);
        }

    }
}
