using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//referencias
using CapaEntidad;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class TipoHabitacionDAL:CadenaDAL
    {
        //metodo para listar tipo habitacion
        public List<TipoHabitacionCLS> ListarTipoHabitacion()
        {
            List<TipoHabitacionCLS> lista = null;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    //llamar procedimineto
                    using (SqlCommand cmd = new SqlCommand("uspListarTipoHabitacion", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader drd = cmd.ExecuteReader();
                        if (drd != null)
                        {
                            lista = new List<TipoHabitacionCLS>();
                            TipoHabitacionCLS oTipoHabitacionCLS;
                            int posId = drd.GetOrdinal("IIDTIPOHABILITACION");
                            int posNombre = drd.GetOrdinal("NOMBRE");
                            int posDescripcion = drd.GetOrdinal("DESCRIPCION");
                            while (drd.Read())
                            {
                                oTipoHabitacionCLS = new TipoHabitacionCLS();
                                oTipoHabitacionCLS.id = drd.IsDBNull(posId) ? 0 : drd.GetInt32(posId);
                                oTipoHabitacionCLS.nombre = drd.IsDBNull(posNombre) ? "" : drd.GetString(posNombre);
                                oTipoHabitacionCLS.descripcion = drd.IsDBNull(posDescripcion) ? "" : drd.GetString(posDescripcion);
                                lista.Add(oTipoHabitacionCLS);
                            }
                        }
                    }
                    cn.Close();
                }
                catch (Exception ex)
                {
                    cn.Close();
                }

            }
            return lista;
        }

        //metodo para filtrar tipo habitacion
        public List<TipoHabitacionCLS> FiltrarTipoHabitacion(string nombreHabitacion)
        {
            List<TipoHabitacionCLS> lista = null;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    //llamar procedimineto
                    using (SqlCommand cmd = new SqlCommand("uspFiltarTipoHabitacion", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombrehabitacion", nombreHabitacion);
                        SqlDataReader drd = cmd.ExecuteReader();
                        if(drd != null)
                        {
                            lista = new List<TipoHabitacionCLS>();
                            TipoHabitacionCLS oTipoHabitacionCLS;
                            int posId = drd.GetOrdinal("IIDTIPOHABILITACION");
                            int posNombre = drd.GetOrdinal("NOMBRE");
                            int posDescripcion = drd.GetOrdinal("DESCRIPCION");
                            while (drd.Read())
                            {
                                oTipoHabitacionCLS = new TipoHabitacionCLS();
                                oTipoHabitacionCLS.id = drd.IsDBNull(posId) ? 0: drd.GetInt32(posId);
                                oTipoHabitacionCLS.nombre = drd.IsDBNull(posNombre) ? "" : drd.GetString(posNombre);
                                oTipoHabitacionCLS.descripcion = drd.IsDBNull(posDescripcion) ? "" : drd.GetString(posDescripcion);
                                lista.Add(oTipoHabitacionCLS);
                            }
                        }
                    }
                    cn.Close();
                }
                catch(Exception ex)
                {
                    cn.Close();
                }
                
            }
            return lista;
        }

        // metodo para guardar tipo habitacion

        public int GuardarTipoHabitacion(TipoHabitacionCLS oTipoHabitacion)
        {
            //crear variable error
            int rtpa = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspGuardarTipohabitacion", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", oTipoHabitacion.id);
                        cmd.Parameters.AddWithValue("@nombre", oTipoHabitacion.nombre);
                        cmd.Parameters.AddWithValue("@descripcion", oTipoHabitacion.descripcion);
                        rtpa = cmd.ExecuteNonQuery();
                        cn.Close();
                    }

                }
                catch (Exception ex)
                {
                    rtpa = 0;
                    cn.Close();
                }
            }
            return rtpa;
        }

        public TipoHabitacionCLS RecuperarTipoHabitacion(int id)
        {
            TipoHabitacionCLS oTipoHabitacionCLS = null;

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    //llamar procedimineto
                    using (SqlCommand cmd = new SqlCommand("uspRecuperarTipoHabitacion", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", id);
                        SqlDataReader drd = cmd.ExecuteReader();
                        if (drd != null)
                        {
                            int posId = drd.GetOrdinal("IIDTIPOHABILITACION");
                            int posNombre = drd.GetOrdinal("NOMBRE");
                            int posDescripcion = drd.GetOrdinal("DESCRIPCION");
                            while (drd.Read())
                            {
                                oTipoHabitacionCLS = new TipoHabitacionCLS();
                                oTipoHabitacionCLS.id = drd.IsDBNull(posId) ? 0 : drd.GetInt32(posId);
                                oTipoHabitacionCLS.nombre = drd.IsDBNull(posNombre) ? "" : drd.GetString(posNombre);
                                oTipoHabitacionCLS.descripcion = drd.IsDBNull(posDescripcion) ? "" : drd.GetString(posDescripcion);
                            }
                        }
                    }
                    cn.Close();
                }
                catch (Exception ex)
                {
                    oTipoHabitacionCLS = null;
                    cn.Close();
                }

            }
            return oTipoHabitacionCLS;
        }

        public int EliminarTipoHabitacion(int id)
        {
            //crear variable error
            int rtpa = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspEliminarTipoHabitacion", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", id);
                        rtpa = cmd.ExecuteNonQuery();
                        cn.Close();
                    }

                }
                catch (Exception ex)
                {
                    rtpa = 0;
                    cn.Close();
                }
            }
            return rtpa;
        }
    }
}
