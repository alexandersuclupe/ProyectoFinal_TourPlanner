using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyecto01.Datos;
using proyecto01.Models;

namespace proyecto01.Controllers
{
    public class ProductoController : Controller
    {
        private readonly AplicacionDbContext _db;

        public ProductoController(AplicacionDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Producto> lista = _db.Producto.Include(c => c.Categoria);
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
        public IActionResult Crear(Producto producto)
        {
            if (ModelState.IsValid)
            {
                _db.Producto.Add(producto);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index)); //redireccionar a la vista principal
            }
            return View(producto); //para retornar la vista con los mismos datos del modelo
        }
        //Get Editar 
        public IActionResult Editar(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.Producto.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //metodo post editar
        [HttpPost]
        public IActionResult Editar(Producto producto)
        {
            if (ModelState.IsValid)
            {
                _db.Producto.Update(producto);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index)); //redireccionar a la vista principal
            }
            return View(producto); //para retornar la vista con los mismos datos del modelo
        }

        //Get Elminar
        public IActionResult Eliminar(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.Producto.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //metodo post elminar
        [HttpPost]
        public IActionResult Eliminar(Producto producto)
        {
            if (producto == null)
            {
                return NotFound();
            }
            _db.Producto.Remove(producto);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index)); //redireccionar a la vista principal
        }
        //get
        public IActionResult Upsert(int? Id)
        {
            Producto producto = new Producto();
            //validar el id que recibe
            if (Id == null)
            {
                //crear un nuevo producto
                return View(producto);
            }
            else
            {
                producto = _db.Producto.Find(Id);
                if (producto == null)
                {
                    return NotFound();
                }
                return View(producto);
            }
        }
    }
}
