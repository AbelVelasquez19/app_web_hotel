using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDatos;
namespace CapaNegocio
{
    public class CamaBL
    {
        public List<CamaCLS> listaCama()
        {
            CamaDAL oCama = new CamaDAL();
            return oCama.ListaCama();
        }
        public List<CamaCLS> FiltrarCama(string nombrecama)
        {
            CamaDAL oCama = new CamaDAL();
            return oCama.FiltrarCama(nombrecama);
        }
        public int GuardarCama(CamaCLS oCama)
        {
            CamaDAL oCamaDal = new CamaDAL();
            return oCamaDal.GuardarCama(oCama);
        }
        public CamaCLS RecuperarCama(int id)
        {
            CamaDAL oCamaDal = new CamaDAL();
            return oCamaDal.RecuperarCama(id);
        }

        public int EliminarCama(int id)
        {
            CamaDAL oCamaDal = new CamaDAL();
            return oCamaDal.EliminarCama(id);
        }
    }
}
