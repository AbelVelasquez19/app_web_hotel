using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;
namespace CapaNegocio
{
    public class TipoHabitacionBL
    {
        public List<TipoHabitacionCLS> ListarTipoHabitacion()
        {
            TipoHabitacionDAL oTipoHabitacionDal = new TipoHabitacionDAL();
            return oTipoHabitacionDal.ListarTipoHabitacion();
        }

        public List<TipoHabitacionCLS> FiltrarTipoHabitacion(string nombreHabitacion)
        {
            TipoHabitacionDAL oTipoHabitacionDal = new TipoHabitacionDAL();
            return oTipoHabitacionDal.FiltrarTipoHabitacion(nombreHabitacion);
        }

        public int GuardarTipoHabitacion(TipoHabitacionCLS oTipoHabitacion)
        {
            TipoHabitacionDAL oTipoHabitacionDal = new TipoHabitacionDAL();
            return oTipoHabitacionDal.GuardarTipoHabitacion(oTipoHabitacion);
        }

        public TipoHabitacionCLS RecuperarTipoHabitacion(int id)
        {
            TipoHabitacionDAL oTipoHabitacionDal = new TipoHabitacionDAL();
            return oTipoHabitacionDal.RecuperarTipoHabitacion(id);
        }

        public int EliminarTipoHabitacion(int id)
        {
            TipoHabitacionDAL oTipoHabitacionDal = new TipoHabitacionDAL();
            return oTipoHabitacionDal.EliminarTipoHabitacion(id);
        }
    }
}
