using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class ProductoBL
    {
        public List<ProductoCLS> listaProducto()
        {
            ProductoDAL oProducto = new ProductoDAL();
            return oProducto.ListaProducto();
        }
        public List<ProductoCLS> FiltrarProductoPorNombre(string nombreProducto)
        {
            ProductoDAL oProducto = new ProductoDAL();
            return oProducto.FiltrarProductoPorNombre(nombreProducto);
        }
    }
}
