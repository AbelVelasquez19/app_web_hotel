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
    public class MarcaBL
    {
        public List<MarcaCLS> listaMarca()
        {
            MarcaDAL oCama = new MarcaDAL();
            return oCama.ListaMarca();
        }

        public List<MarcaCLS> FiltrarMarca(string nombreMarca)
        {
            MarcaDAL oCama = new MarcaDAL();
            return oCama.FiltrarMarca(nombreMarca);
        }

        public int GuardarMarca(MarcaCLS oMarca)
        {
            MarcaDAL oMarcaDal = new MarcaDAL();
            return oMarcaDal.GuardarMarca(oMarca);
        }
        public MarcaCLS RecuperarMarca(int id)
        {
            MarcaDAL oMarcaDal = new MarcaDAL();
            return oMarcaDal.RecuperarMarca(id);
        }

        public int EliminarMarca(int id)
        {
            MarcaDAL oMarcaDal = new MarcaDAL();
            return oMarcaDal.EliminarMarca(id);
        }
    }
}
