﻿using Microsoft.AspNetCore.Mvc;
using proyecto01.Datos;
using proyecto01.Models;

namespace proyecto01.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly AplicacionDbContext _db;

        public CategoriaController(AplicacionDbContext db)
        {
            _db= db;
        }
        public IActionResult Index()
        {
            IEnumerable<Categoria> lista = _db.Categoria;
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
        public IActionResult Crear(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _db.Categoria.Add(categoria);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index)); //redireccionar a la vista principal
            }
            return View(categoria); //para retornar la vista con los mismos datos del modelo
        }
        //Get Editar 
        public IActionResult Editar(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.Categoria.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //metodo post editar
        [HttpPost]
        public IActionResult Editar(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _db.Categoria.Update(categoria);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index)); //redireccionar a la vista principal
            }
            return View(categoria); //para retornar la vista con los mismos datos del modelo
        }

        //Get Elminar
        public IActionResult Eliminar(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.Categoria.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //metodo post elminar
        [HttpPost]
        public IActionResult Eliminar(Categoria categoria)
        {
            if (categoria==null)
            {
                return NotFound();
            }
            _db.Categoria.Remove(categoria);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index)); //redireccionar a la vista principal
        }
    }
}
