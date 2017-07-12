using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeccionMVC.Models;

namespace LeccionMVC.Controllers
{
    public class OperacionesController : Controller
    {

        [HttpGet]
        public ViewResult PruebaSolicitud()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Resultado(Persona val)
        {
            return View(val);
        }

        public ViewResult Accion(string nombre)
        {
            
            return View(model:nombre);
        }

        // GET: Operaciones
        public int SumaDeDosNumeros(int? n1, int? n2)
        {
            if (!n1.HasValue)
                n1 = 2;
            if (!n2.HasValue)
                n2 = 2;

            return (n1.Value + n2.Value);
        }

        public DateTime VerFecha()
        {
            return DateTime.Now;
        }

        public string GetMensajeBienvenida(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
                nombre = "Inserte su nombre en la variable 'nombre'";

            return string.Format("Saludos: {0}", nombre);
        }

        public Persona VerPersona()
        {
            Persona temp = new Persona()
            {
                Nombre = "Euxequiel",
                Apellido = "Monereaux",
                FechaNacimiento = new DateTime(1996, 7, 28)
            };

            string personaString = temp.ToString();

            return temp;
        }


     
    }
}