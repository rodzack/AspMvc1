using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                TempData["mensajeAlerta"] = "<script>alert('Debes estar logeado primero');</script>";
                return RedirectToAction("Inicio", "Ingresar");
            }
            else
            {
                ViewBag.listaActividades = (from a in db.tblActividades.AsEnumerable().Where(a => a.ActIdUsuario == Convert.ToInt32(Session["IdUsuario"]))
                                            select a).ToList();
                return View();
            }           
        }

        public ActionResult EditarActividad(int idActividad)
        {
               var actividad = db.tblActividades.Find(idActividad);
                if (actividad == null)
                {
                    return HttpNotFound();
                }

            return View(actividad);
        }

        [HttpPost]
        public ActionResult EditarActividad(tblActividades actividades)
        {
            if (ModelState.IsValid)
            {
                //actividades.ActIdUsuario = Convert.ToInt32(Session["IdUsuario"]);
                db.Entry(actividades).State = EntityState.Modified;
                db.SaveChanges();
            }

            return View(actividades);
        }

    }
}
