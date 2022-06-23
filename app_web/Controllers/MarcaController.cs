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
    public class MarcaController : Controller
    {
        // GET: Marca
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult ListarMarca()
        {
            MarcaBL obj = new MarcaBL();
            return Json(obj.listaMarca(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult FiltrarMarca(string nombreMarca)
        {
            MarcaBL obj = new MarcaBL();
            return Json(obj.FiltrarMarca(nombreMarca), JsonRequestBehavior.AllowGet);
        }

        public int GuardarDatos(MarcaCLS oMarca)
        {
            MarcaBL obj = new MarcaBL();
            return obj.GuardarMarca(oMarca);
        }

        public JsonResult RecuperarMarca(int id)
        {
            MarcaBL obj = new MarcaBL();
            return Json(obj.RecuperarMarca(id), JsonRequestBehavior.AllowGet);
        }

        public int EliminarMarca(int id)
        {
            MarcaBL obj = new MarcaBL();
            return obj.EliminarMarca(id);
        }
    }
}