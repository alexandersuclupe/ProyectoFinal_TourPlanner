using Microsoft.AspNetCore.Mvc;
using proyecto01.Datos;
using proyecto01.Models;

namespace proyecto01.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly AplicacionDbContext _db;

        public UsuarioController(AplicacionDbContext db)
        {
            _db= db;
        }
        public IActionResult Index()
        {
            IEnumerable<Usuario> lista = _db.Usuario;
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
        public IActionResult Crear(Usuario usu)
        {
            if (ModelState.IsValid)
            {
                _db.Usuario.Add(usu);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index)); //redireccionar a la vista principal
            }
            return View(usu); //para retornar la vista con los mismos datos del modelo
        }
        //Get Editar 
        public IActionResult Editar(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.Usuario.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //metodo post editar
        [HttpPost]
        public IActionResult Editar(Usuario usu)
        {
            if (ModelState.IsValid)
            {
                _db.Usuario.Update(usu);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index)); //redireccionar a la vista principal
            }
            return View(usu); //para retornar la vista con los mismos datos del modelo
        }

        //Get Elminar
        public IActionResult Eliminar(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.Usuario.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //metodo post elminar
        [HttpPost]
        public IActionResult Eliminar(Usuario usu)
        {
            if (usu == null)
            {
                return NotFound();
            }
            _db.Usuario.Remove(usu);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index)); //redireccionar a la vista principal
        }
    }
}
