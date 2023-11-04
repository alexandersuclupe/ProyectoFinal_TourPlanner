using Microsoft.AspNetCore.Mvc;
using proyecto01.Datos;
using proyecto01.Models;

namespace proyecto01.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly AplicacionDbContext _db;

        public UsuariosController(AplicacionDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Usuarios> lista = _db.Usuarios;
            return View(lista);
        }
        //METODO GET
        public IActionResult Crear()
        {

            return View();
        }
    }
}
