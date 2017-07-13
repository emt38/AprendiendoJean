using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeccionMVC.Models;

namespace LeccionMVC.Controllers
{
    public class PeliculasController : Controller
    {
        // GET: Peliculas
        public ActionResult Index()
        {
            return View(Pelicula.ToList());
        }

        // GET: Peliculas/Details/5
        public ActionResult Details(int id)
        {
            return View(Pelicula.Get(id));
        }

        // GET: Peliculas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Peliculas/Create
        [HttpPost]
        public ActionResult Create(Pelicula nueva)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(nueva);

                if(nueva.IsDuplicated())
                {
                    ViewBag.Mssg = "La pelicula está duplicada";
                    return View(nueva);
                }

                nueva.Insert();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Peliculas/Edit/5
        public ActionResult Edit(int id)
        {
            return View(Pelicula.Get(id));
        }

        // POST: Peliculas/Edit/5
        [HttpPost]
        public ActionResult Edit(Pelicula modificada)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(modificada);

                modificada.Update();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Peliculas/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Pelicula.Get(id));
        }

        // POST: Peliculas/Delete/5
        [HttpPost]
        public ActionResult Delete(Pelicula peli)
        {
            try
            {
                peli.Delete();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
