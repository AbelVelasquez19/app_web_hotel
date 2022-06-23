using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaNegocio;
using CapaEntidad;
namespace app_web.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarCategoria()
        {
           CategoriaBL obj = new CategoriaBL();
            return Json(obj.listaCategoria(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult FiltrarCategoria(string nombreCategoria)
        {
            CategoriaBL obj = new CategoriaBL();
            return Json(obj.FiltrarCategoria(nombreCategoria), JsonRequestBehavior.AllowGet);
        }

        public int GuardarDatos(CategoriaCLS oCategoria)
        {
            CategoriaBL obj = new CategoriaBL();
            return obj.GuardarCategoria(oCategoria);
        }

        public JsonResult RecuperarCategoria(int id)
        {
            CategoriaBL obj = new CategoriaBL();
            return Json(obj.RecuperarCategoria(id), JsonRequestBehavior.AllowGet);
        }

        public int EliminarCategoria(int id)
        {
            CategoriaBL obj = new CategoriaBL();
            return obj.EliminarCategoria(id);
        }
    }
}