using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aplicacion_Web_3.Models;

namespace Aplicacion_Web_3.Controllers
{
    public class ActividadesController : Controller
    {
        private ActividadesEntities db = new ActividadesEntities();

        // GET: Actividades
        public ActionResult InicioActividad()
        {
            if (Session["IdUsuario"] == null)
            {
                ViewData["alertLogeo"] = "<script>alert('Debe estar logeado')</script>";
                return RedirectToAction("Inicio", "Ingresar");
            }
            else
            {
                ViewBag.listaActividades = (from a in db.tblActividades.AsEnumerable().Where(a => a.ActIdUsuario == Convert.ToInt32(Session["IdUsuario"]))
                                            select a).ToList();
                return View();
            }           
        }

    }
}
