using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Aplicacion_Web_3.Models;

namespace Aplicacion_Web_3.Controllers
{
    public class IngresoController : Controller
    {
        private ActividadesEntities db = new ActividadesEntities();

        // GET: Ingreso
        public ActionResult Index()
        {
            return View(db.TblUsuarios.ToList());
        }

        // GET: Ingreso/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblUsuarios tblUsuarios = db.TblUsuarios.Find(id);
            if (tblUsuarios == null)
            {
                return HttpNotFound();
            }
            return View(tblUsuarios);
        }

        // GET: Ingreso/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ingreso/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdUsuario,NombreUsuario,Contrasenia")] TblUsuarios tblUsuarios)
        {
            if (ModelState.IsValid)
            {
                db.TblUsuarios.Add(tblUsuarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblUsuarios);
        }

        // GET: Ingreso/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblUsuarios tblUsuarios = db.TblUsuarios.Find(id);
            if (tblUsuarios == null)
            {
                return HttpNotFound();
            }
            return View(tblUsuarios);
        }

        // POST: Ingreso/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdUsuario,NombreUsuario,Contrasenia")] TblUsuarios tblUsuarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblUsuarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblUsuarios);
        }

        // GET: Ingreso/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblUsuarios tblUsuarios = db.TblUsuarios.Find(id);
            if (tblUsuarios == null)
            {
                return HttpNotFound();
            }
            return View(tblUsuarios);
        }

        // POST: Ingreso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblUsuarios tblUsuarios = db.TblUsuarios.Find(id);
            db.TblUsuarios.Remove(tblUsuarios);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
