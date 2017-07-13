using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeccionMVC.Models;

namespace LeccionMVC.Controllers
{
    public class ActoresController : Controller
    {
        // GET: Actores
        public ActionResult Index()
        {
            return View(Actor.Listar());
        }

        [HttpGet]
        public ActionResult Insertar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insertar(Actor nuevo)
        {
            if (!ModelState.IsValid)
                return View(nuevo);

            nuevo.Insertar();
            return RedirectToAction("Index");
        }
    }
}