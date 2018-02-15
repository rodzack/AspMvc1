using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aplicacion_Web_3.Models;

namespace Aplicacion_Web_3.Controllers
{
    public class IngresarController : Controller
    {
        private ActividadesEntities db = new ActividadesEntities();

        // GET: Ingresar
        public ActionResult Inicio()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Inicio(TblUsuarios tblUsuarios)
        {

            //if (ModelState.IsValid)
            //{
                //var IdUsuario = (from B in db.TblUsuarios.Where(a => a.NombreUsuario == tblUsuarios.NombreUsuario && a.Contrasenia == tblUsuarios.Contrasenia)
                //             select new tblActividades { ActIdUsuario = B.IdUsuario});
                var IdUsuario = db.TblUsuarios.Where(a => a.NombreUsuario == tblUsuarios.NombreUsuario && a.Contrasenia == tblUsuarios.Contrasenia).Select(a => a.IdUsuario).FirstOrDefault();

                if (IdUsuario == 0)
                {
                    return Json(new { mensaje = "Los datos de acceso son incorrectos" });
                }
                else
                {
                    Session["IdUsuario"] = IdUsuario;
                    return Json(new { url = Url.Action("InicioActividad", "Actividades") });
                }
            //}
            //else
            //{
            //    return Json (new { mensaje = "Hubo un error" })
            //}
        }
    }
}
