using FruitStore.Areas.Admin.Models;
using FruitStore.Models.Entities;
using FruitStore.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FruitStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriasController : Controller
    {
        public CategoriasController(Repository<Categorias> repository )
        {
            Repository = repository;
        }

        public Repository<Categorias> Repository { get; }

        public IActionResult Index()
        {
            AdminCategoriaViewModel vm = new();

            vm.Categorias = Repository.GetAll().OrderBy(x => x.Nombre).Select(x => new CategoriaModel
            {
                Id = x.Id,
                Nombre=x.Nombre ?? ""
            }) ;
            return View(vm);
        }

        [HttpGet]
        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(Categorias c)
        {
            if (string.IsNullOrWhiteSpace(c.Nombre))
            {
                ModelState.AddModelError("", "Escriba el nombre de la categoria");
            }

            if (ModelState.IsValid)
            {
                Repository.Incert(c);
                return RedirectToAction("Index");
            }

            return View(c);
        }
    }
}
