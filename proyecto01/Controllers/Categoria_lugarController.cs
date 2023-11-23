using Microsoft.AspNetCore.Mvc;
using proyecto01.Datos;
using proyecto01.Models;

namespace proyecto01.Controllers
{
    public class Categoria_lugarController : Controller
    {
        private readonly AplicacionDbContext _db;

        public Categoria_lugarController(AplicacionDbContext db)
        {
            _db= db;
        }
        public IActionResult Index()
        {
            IEnumerable<Categoria_lugar> lista = _db.Categoria_lugar;
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
        public IActionResult Crear(Categoria_lugar categoria_lugar)
        {
            if (ModelState.IsValid)
            {
                _db.Categoria_lugar.Add(categoria_lugar);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index)); //redireccionar a la vista principal
            }
            return View(categoria_lugar); //para retornar la vista con los mismos datos del modelo
        }
        //Get Editar 
        public IActionResult Editar(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.Categoria_lugar.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //metodo post editar
        [HttpPost]
        public IActionResult Editar(Categoria_lugar categoria_lugar)
        {
            if (ModelState.IsValid)
            {
                _db.Categoria_lugar.Update(categoria_lugar);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index)); //redireccionar a la vista principal
            }
            return View(categoria_lugar); //para retornar la vista con los mismos datos del modelo
        }

        //Get Elminar
        public IActionResult Eliminar(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.Categoria_lugar.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //metodo post elminar
        [HttpPost]
        public IActionResult Eliminar(Categoria_lugar categoria_lugar)
        {
            if (categoria_lugar==null)
            {
                return NotFound();
            }
            _db.Categoria_lugar.Remove(categoria_lugar);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index)); //redireccionar a la vista principal
        }
    }
}
