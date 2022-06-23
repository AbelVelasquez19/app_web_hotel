using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//referencias
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class CategoriaBL
    {
        public List<CategoriaCLS> listaCategoria()
        {
            CategoriaDAL oCategoria = new CategoriaDAL();
            return oCategoria.ListaCategoria();
        }

        public List<CategoriaCLS> FiltrarCategoria(string nombreCategoria)
        {
            CategoriaDAL oCategoria = new CategoriaDAL();
            return oCategoria.FiltrarCategoria(nombreCategoria);
        }

        public int GuardarCategoria(CategoriaCLS oCategoria)
        {
            CategoriaDAL oCategoriaDAL = new CategoriaDAL();
            return oCategoriaDAL.GuardarCategoria(oCategoria);
        }
        public CategoriaCLS RecuperarCategoria(int id)
        {
            CategoriaDAL oCategoriaDAL = new CategoriaDAL();
            return oCategoriaDAL.RecuperarCategoria(id);
        }

        public int EliminarCategoria(int id)
        {
            CategoriaDAL oCategoriaDAL = new CategoriaDAL();
            return oCategoriaDAL.EliminarCategoria(id);
        }
    }
}
