using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aplicacion_Web_3.Models;

namespace Aplicacion_Web_3.Controllers
{
    public class RegistroController : Controller
    {
        private ActividadesEntities db = new ActividadesEntities();

        // GET: Registro
        public ActionResult Index()
        {
            //var listaUsuarios = db.TblUsuarios.ToList();

            var listaUsuarios = (from A in db.TblUsuarios.AsEnumerable()
                             select new TblUsuarios
                             {
                                 IdUsuario = A.IdUsuario,
                                 NombreUsuario = A.NombreUsuario,
                                 Contrasenia = A.Contrasenia
                             }).ToList();

            return View(listaUsuarios);
        }

        // POST: Registro/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Registro/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Registro/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Registro/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Registro/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
