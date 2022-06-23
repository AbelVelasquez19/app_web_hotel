using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//referencia
using CapaNegocio;
using CapaEntidad;

namespace app_web.Controllers
{
    public class CamaController : Controller
    {
        // GET: Cama
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Listar()
        {
            CamaBL obj = new CamaBL();
            return Json(obj.listaCama(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult FiltrarCama(string nombrecama)
        {
            CamaBL obj = new CamaBL();
            return Json(obj.FiltrarCama(nombrecama), JsonRequestBehavior.AllowGet);
        }

        public int GuardarDatos(CamaCLS oCama)
        {
            CamaBL obj = new CamaBL();
            return obj.GuardarCama(oCama);
        }

        public JsonResult RecuperarCama(int id)
        {
            CamaBL obj = new CamaBL();
            return Json(obj.RecuperarCama(id), JsonRequestBehavior.AllowGet);
        }

        public int EliminarCama(int id)
        {
            CamaBL obj = new CamaBL();
            return obj.EliminarCama(id);
        }
    }
}