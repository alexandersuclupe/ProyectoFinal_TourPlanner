using Microsoft.AspNetCore.Mvc;
using proyecto01.Datos;
using proyecto01.Models;

namespace proyecto01.Controllers
{
    public class UbigeoController : Controller
    {
        private readonly AplicacionDbContext _db;

        public UbigeoController(AplicacionDbContext db)
        {
            _db= db;
        }
        public IActionResult Index()
        {
            IEnumerable<Ubigeo> lista = _db.Ubigeo;
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
        public IActionResult Crear(Ubigeo ubi)
        {
            if (ModelState.IsValid)
            {
                _db.Ubigeo.Add(ubi);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index)); //redireccionar a la vista principal
            }
            return View(ubi); //para retornar la vista con los mismos datos del modelo
        }
        //Get Editar 
        public IActionResult Editar(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.Ubigeo.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //metodo post editar
        [HttpPost]
        public IActionResult Editar(Ubigeo ubi)
        {
            if (ModelState.IsValid)
            {
                _db.Ubigeo.Update(ubi);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index)); //redireccionar a la vista principal
            }
            return View(ubi); //para retornar la vista con los mismos datos del modelo
        }

        //Get Elminar
        public IActionResult Eliminar(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.Ubigeo.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //metodo post elminar
        [HttpPost]
        public IActionResult Eliminar(Ubigeo ubi)
        {
            if (ubi == null)
            {
                return NotFound();
            }
            _db.Ubigeo.Remove(ubi);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index)); //redireccionar a la vista principal
        }
    }
}
