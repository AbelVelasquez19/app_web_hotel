using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace app_web.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarProducto()
        {
            ProductoBL obj = new ProductoBL();
            return Json(obj.listaProducto(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult FiltrarProductoPorNombre(string nombreProducto)
        {
            ProductoBL obj = new ProductoBL();
            return Json(obj.FiltrarProductoPorNombre(nombreProducto), JsonRequestBehavior.AllowGet);
        }
    }
}