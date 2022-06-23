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
    public class CamaDAL:CadenaDAL
    {
        public List<CamaCLS> ListaCama()
        {
            List<CamaCLS> lista = null;

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    //llamar procedimineto
                    using (SqlCommand cmd = new SqlCommand("uspListarCama", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader drd = cmd.ExecuteReader();
                        if (drd != null)
                        {
                            lista = new List<CamaCLS>();
                            CamaCLS oCamaCLS;
                            int posId = drd.GetOrdinal("IIDCAMA");
                            int posNombre = drd.GetOrdinal("NOMBRE");
                            int posDescripcion = drd.GetOrdinal("DESCRIPCION");
                            while (drd.Read())
                            {
                                oCamaCLS = new CamaCLS();
                                oCamaCLS.id = drd.IsDBNull(posId)?0: drd.GetInt32(posId);
                                oCamaCLS.nombre = drd.IsDBNull(posNombre) ? "" :  drd.GetString(posNombre);
                                oCamaCLS.descripcion = drd.IsDBNull(posDescripcion) ? "" : drd.GetString(posDescripcion);
                                lista.Add(oCamaCLS);
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


        public List<CamaCLS> FiltrarCama(string nombreCama)
        {
            List<CamaCLS> lista = null;

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    //llamar procedimineto
                    using (SqlCommand cmd = new SqlCommand("uspFiltarCama", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombrecama", nombreCama);
                        SqlDataReader drd = cmd.ExecuteReader();
                        if (drd != null)
                        {
                            lista = new List<CamaCLS>();
                            CamaCLS oCamaCLS;
                            int posId = drd.GetOrdinal("IIDCAMA");
                            int posNombre = drd.GetOrdinal("NOMBRE");
                            int posDescripcion = drd.GetOrdinal("DESCRIPCION");
                            while (drd.Read())
                            {
                                oCamaCLS = new CamaCLS();
                                oCamaCLS.id = drd.IsDBNull(posId) ? 0 : drd.GetInt32(posId);
                                oCamaCLS.nombre = drd.IsDBNull(posNombre) ? "" : drd.GetString(posNombre);
                                oCamaCLS.descripcion = drd.IsDBNull(posDescripcion) ? "" : drd.GetString(posDescripcion);
                                lista.Add(oCamaCLS);
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

        public int GuardarCama(CamaCLS oCama)
        {
            //crear variable error
            int rtpa = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspGuardarCama", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", oCama.id);
                        cmd.Parameters.AddWithValue("@nombre", oCama.nombre);
                        cmd.Parameters.AddWithValue("@descripcion", oCama.descripcion);
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

        public CamaCLS RecuperarCama(int id)
        {
            CamaCLS oCamaCLS = null;

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    //llamar procedimineto
                    using (SqlCommand cmd = new SqlCommand("uspRecuperarCama", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", id);
                        SqlDataReader drd = cmd.ExecuteReader();
                        if (drd != null)
                        {
                            int posId = drd.GetOrdinal("IIDCAMA");
                            int posNombre = drd.GetOrdinal("NOMBRE");
                            int posDescripcion = drd.GetOrdinal("DESCRIPCION");
                            while (drd.Read())
                            {
                                oCamaCLS = new CamaCLS();
                                oCamaCLS.id = drd.IsDBNull(posId) ? 0 : drd.GetInt32(posId);
                                oCamaCLS.nombre = drd.IsDBNull(posNombre) ? "" : drd.GetString(posNombre);
                                oCamaCLS.descripcion = drd.IsDBNull(posDescripcion) ? "" : drd.GetString(posDescripcion);
                            }
                        }
                    }
                    cn.Close();
                }
                catch (Exception ex)
                {
                    oCamaCLS = null;
                    cn.Close();
                }

            }
            return oCamaCLS;
        }

        public int EliminarCama(int id)
        {
            //crear variable error
            int rtpa = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspEliminarCama", cn))
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
