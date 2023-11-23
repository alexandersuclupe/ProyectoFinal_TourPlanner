using Microsoft.AspNetCore.Mvc;
using proyecto01.Datos;
using proyecto01.Models;

namespace proyecto01.Controllers
{
    public class Categoria_establecimientoController : Controller
    {
        private readonly AplicacionDbContext _db;

        public Categoria_establecimientoController(AplicacionDbContext db)
        {
            _db= db;
        }
        public IActionResult Index()
        {
            IEnumerable<Categoria_establecimiento> lista = _db.Categoria_establecimiento;
            return View(lista);
        }
        //METODO GET
        public IActionResult Crear()
        {
            
            return View();
        }
        //METODO POST
        //PARA QUE GUARDE LOS DATOS EN LA BD
        [HttpPost]
        public IActionResult Crear(Categoria_establecimiento categoria_establecimiento)
        {
            if (ModelState.IsValid)
            {
                _db.Categoria_establecimiento.Add(categoria_establecimiento);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index)); //redireccionar a la vista principal
            }
            return View(categoria_establecimiento); //para retornar la vista con los mismos datos del modelo
        }
        //Get Editar 
        public IActionResult Editar(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.Categoria_establecimiento.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //metodo post editar
        [HttpPost]
        public IActionResult Editar(Categoria_establecimiento categoria_establecimiento)
        {
            if (ModelState.IsValid)
            {
                _db.Categoria_establecimiento.Update(categoria_establecimiento);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index)); //redireccionar a la vista principal
            }
            return View(categoria_establecimiento); //para retornar la vista con los mismos datos del modelo
        }

        //Get Elminar
        public IActionResult Eliminar(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.Categoria_establecimiento.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //metodo post elminar
        [HttpPost]
        public IActionResult Eliminar(Categoria_establecimiento categoria_establecimiento)
        {
            if (categoria_establecimiento==null)
            {
                return NotFound();
            }
            _db.Categoria_establecimiento.Remove(categoria_establecimiento);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index)); //redireccionar a la vista principal
        }
    }
}
