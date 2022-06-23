using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaNegocio;
using CapaEntidad;
namespace app_web.Controllers
{
    public class TipoHabitacionController : Controller
    {
        // GET: TipoHabitacion
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Guardar()
        {
            return View();
        }

        public ActionResult Inicio()
        {
            return View();
        }
        public JsonResult Listar()
        {
            TipoHabitacionBL obj = new TipoHabitacionBL();
            return Json(obj.ListarTipoHabitacion(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult FiltrarTipoHabitacionNombre(string nombreHabitacion)
        {
            TipoHabitacionBL obj = new TipoHabitacionBL();
            return Json(obj.FiltrarTipoHabitacion(nombreHabitacion), JsonRequestBehavior.AllowGet);
        }

        public int GuardarDatos(TipoHabitacionCLS oTipoHabitacion){
            TipoHabitacionBL obj = new TipoHabitacionBL();
            return obj.GuardarTipoHabitacion(oTipoHabitacion);
        }

        public JsonResult RecuperarTipoHabitacion(int id)
        {
            TipoHabitacionBL obj = new TipoHabitacionBL();
            return Json(obj.RecuperarTipoHabitacion(id), JsonRequestBehavior.AllowGet);
        }

        public int EliminarDatos(int id)
        {
            TipoHabitacionBL obj = new TipoHabitacionBL();
            return obj.EliminarTipoHabitacion(id);
        }
    }
}