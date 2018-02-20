using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Aplicacion_Web_3.Models;

namespace Aplicacion_Web_3.Controllers
{
    public class WebApiController : ApiController
    {

        private ActividadesEntities db = new ActividadesEntities();

        [HttpPost]
        [Route("api/actividad")]
        public List<tblActividades> actividad(tblActividades actividades)
        {
            db.tblActividades.Add(actividades);
            db.SaveChanges();

            var listActividades = (from A in db.tblActividades.AsEnumerable().Where(m => m.ActIdUsuario == actividades.ActIdUsuario)
                                   select new tblActividades
                                   {
                                       idActividad = A.idActividad,
                                       DescripcionActividad = A.DescripcionActividad,
                                       ActIdUsuario = A.ActIdUsuario
                                   }).ToList();
            return listActividades;
        }

        [HttpPost]
        [Route("api/AgregarHoras")]
        public IHttpActionResult AgregarHoras(tblHorasActividades horasActividades)
        {
            var cantidadHoras = db.tblHorasActividades.Where(a => a.HorAct_IdActividad == horasActividades.HorAct_IdActividad).Select(a => a.HorAct_CantidadHoras).DefaultIfEmpty(0).Sum();

            if (cantidadHoras + horasActividades.HorAct_CantidadHoras <= 8)
            {
                db.tblHorasActividades.Add(horasActividades);
                db.SaveChanges();

                var listaHoras = (from A in db.tblHorasActividades.AsEnumerable().Where(a => a.HorAct_IdActividad == horasActividades.HorAct_IdActividad)
                                  select new tblHorasActividades
                                  {
                                      HorAct_CantidadHoras = A.HorAct_CantidadHoras,
                                      HorAct_IdActividad = A.HorAct_IdActividad,
                                      HorAct_Fecha = A.HorAct_Fecha,
                                      HorAct_IdHoras = A.HorAct_IdHoras
                                  }).ToList();
                return Ok(listaHoras);
            }
            else
            {
                return Json(new { mensaje = "La cantidad de horas supera el maximo permitido" });
            }

        }

        [HttpPost]
        [Route("api/CrearUsuario")]
        public List<TblUsuarios> CrearUsuario(TblUsuarios usuarios)
        {
            //db.TblUsuarios.Add(usuarios);
            //db.SaveChanges();

            var listaUsuarios = (from A in db.TblUsuarios.AsEnumerable()
                                 select new TblUsuarios
                                 {
                                     IdUsuario = A.IdUsuario,
                                     NombreUsuario = A.NombreUsuario,
                                     Contrasenia = A.Contrasenia
                                 }).ToList();

            return listaUsuarios;
        }


    }
}