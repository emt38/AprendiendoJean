using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeccionMVC.Controllers
{
    public class HomeController : Controller
    {
        public class alumno
        {
            public string nombre { get; set; }
            public int edad { get; set; }
        }



        public ViewResult Index()
        {
            return View();

        }


        [HttpPost]
        public ViewResult About()
        {
          ViewBag.Message = "Your application description page.";

          return View();



        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public FileResult archivo()
        {
            var ruta = Server.MapPath("Diplomado.pdf");
            return File(ruta, "ApplicationException/pdf", "Diplomado.pdf");
        }


        [HttpPost]

        public JsonResult prueba()
        {
            //            ViewBag.Message = "Your application description page.";

            //           return View();

            var alumno1 = new alumno { nombre = "jeancarlos", edad = 24 };
            return Json(alumno1);
        }
      
        public RedirectResult enlace()
        {
            return Redirect("https://www.google.com.do/");
        }

        public JavaScriptResult java()
        {
            string js = "@var numero = 2*5;";

            return JavaScript(js);
        }

    }
}