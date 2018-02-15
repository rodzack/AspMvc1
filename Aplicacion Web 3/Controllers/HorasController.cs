using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aplicacion_Web_3.Models;

namespace Aplicacion_Web_3.Controllers
{
    public class HorasController : Controller
    {
        private ActividadesEntities db = new ActividadesEntities();

        // GET: Horas
        public ActionResult InicioHoras(int HorAct_IdActividad)
        {
            ViewBag.idHorActividad = HorAct_IdActividad;
            ViewBag.listaHoras = (from a in db.tblHorasActividades.AsEnumerable().Where(a => a.HorAct_IdActividad == HorAct_IdActividad)
                                  select new tblHorasActividades
                                  {
                                      HorAct_CantidadHoras = a.HorAct_CantidadHoras,
                                      HorAct_IdActividad = a.HorAct_IdActividad,
                                      HorAct_Fecha = a.HorAct_Fecha,
                                      HorAct_IdHoras = a.HorAct_IdHoras
                                  }).ToList();

            return View();
        }

       
    }
}
