using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using proyecto01;
using proyecto01.Datos;
using proyecto01.Models;
using proyecto01.Models.ViewModels;


namespace Proyecto01.Controllers
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
            IEnumerable<Lugar> lista = _db.Lugar.Include(u => u.Ubigeo)
                                                .Include(c => c.Categoria_lugar);
            
            return View(lista);
        }
        //Get
        public IActionResult Upsert(int? Id)
        {
            //IEnumerable<SelectListItem> categoriaDropDown = _db.Categoria.Select(c => new SelectListItem
            //{
            //    Text=c.nombre_categoria,
            //    Value=c.Id.ToString(),
            //});
            //ViewBag.categoriaDropDown= categoriaDropDown;

            //Producto producto = new Producto();
            LugarVM lugarVM = new LugarVM()
            {
                Lugar = new Lugar(),
                ListacategoriaLugar = _db.Categoria_lugar.Select(c => new SelectListItem

                {
                    Text = c.nombre,
                    Value = c.Id.ToString(),
                }),

                Listaubigeo = _db.Ubigeo.Select(u => new SelectListItem

                {
                    Text = u.departamento,
                    Value = u.Id.ToString(),
                })


            };
            //Validar el id que recibe
            if (Id == null)
            {
                //Crear un nuevo producto
                return View(lugarVM);
            }
            else
            {
                lugarVM.Lugar = _db.Lugar.Find(Id);
                if (lugarVM.Lugar == null)
                {
                    return NotFound();
                }
                return View(lugarVM);
            }
        }
        //Metodo Post
        [HttpPost]
        public IActionResult Upsert(LugarVM lugarVM)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                string webRootPath = _webHostEnvironment.WebRootPath;
                if (lugarVM.Lugar.Id == 0)
                {
                    //Nuevo Producto
                    string upload = webRootPath + WC.ImagenRuta;
                    string filename = Guid.NewGuid().ToString(); // asigna un id automatico a la imagen que se va a grabar
                    string extension = Path.GetExtension(files[0].FileName);
                    using (var fileString = new FileStream(Path.Combine(upload, filename + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileString);
                    }
                    lugarVM.Lugar.imagenUrl = filename + extension;
                    _db.Lugar.Add(lugarVM.Lugar);
                }
                else
                {
                    //Editar Producto
                    var objLugar = _db.Lugar.AsNoTracking().FirstOrDefault(p => p.Id == lugarVM.Lugar.Id);
                    if (files.Count > 0) //Se carga una nueva imagen
                    {
                        string upload = webRootPath + WC.ImagenRuta;
                        string filename = Guid.NewGuid().ToString(); // asigna un id automatico a la imagen que se va a grabar
                        string extension = Path.GetExtension(files[0].FileName);
                        //Esta parte borra la imagen anterior
                        var anteriorFile = Path.Combine(upload, objLugar.imagenUrl);
                        if (System.IO.File.Exists(anteriorFile))
                        {
                            System.IO.File.Delete(anteriorFile);
                        }
                        using (var fileString = new FileStream(Path.Combine(upload, filename + extension), FileMode.Create))
                        {
                            files[0].CopyTo(fileString);
                        }
                        lugarVM.Lugar.imagenUrl = filename + extension;
                        _db.Lugar.Update(lugarVM.Lugar);
                    }
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lugarVM);
        }
    }
}
