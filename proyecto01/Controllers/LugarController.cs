using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyecto01.Datos;
using proyecto01.Models;

namespace proyecto01.Controllers
{
    public class LugarController : Controller
    {
        private readonly AplicacionDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public LugarController(AplicacionDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            IEnumerable<Lugar> lista = _db.Lugar.Include(c => c.Categoria_lugar);
                                                
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
        public IActionResult Crear(Lugar lug)
        {
            if (ModelState.IsValid)
            {
                _db.Lugar.Add(lug);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index)); //redireccionar a la vista principal
            }
            return View(lug); //para retornar la vista con los mismos datos del modelo
        }
        //Get Editar 
        public IActionResult Editar(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.Lugar.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //metodo post editar
        [HttpPost]
        public IActionResult Editar(Lugar lug)
        {
            if (ModelState.IsValid)
            {
                _db.Lugar.Update(lug);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index)); //redireccionar a la vista principal
            }
            return View(lug); //para retornar la vista con los mismos datos del modelo
        }

        //Get Elminar
        public IActionResult Eliminar(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.Lugar.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //metodo post elminar
        [HttpPost]
        public IActionResult Eliminar(Lugar lug)
        {
            if (lug == null)
            {
                return NotFound();
            }
            _db.Lugar.Remove(lug);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index)); //redireccionar a la vista principal
        }
        //get
        public IActionResult Upsert(int? Id)
        {
            Lugar lug = new Lugar();
            //validar el id que recibe
            if (Id == null)
            {
                //crear un nuevo producto
                return View(lug);
            }
            else
            {
                lug = _db.Lugar.Find(Id);
                if (lug == null)
                {
                    return NotFound();
                }
                return View(lug);
            }
        }
    }
}
