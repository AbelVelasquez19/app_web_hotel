using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
   public class CategoriaDAL:CadenaDAL
    {
        public List<CategoriaCLS> ListaCategoria()
        {
            List<CategoriaCLS> lista = null;

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    //llamar procedimineto
                    using (SqlCommand cmd = new SqlCommand("uspListarCategorias", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader drd = cmd.ExecuteReader();
                        if (drd != null)
                        {
                            lista = new List<CategoriaCLS>();
                            CategoriaCLS oCategoriaClS;
                            int posId = drd.GetOrdinal("IIDCATEGORIA");
                            int posNombre = drd.GetOrdinal("NOMBRE");
                            int posDescripcion = drd.GetOrdinal("DESCRIPCION");
                            while (drd.Read())
                            {
                                oCategoriaClS = new CategoriaCLS();
                                oCategoriaClS.id = drd.IsDBNull(posId) ? 0 : drd.GetInt32(posId);
                                oCategoriaClS.nombre = drd.IsDBNull(posNombre) ? "" : drd.GetString(posNombre);
                                oCategoriaClS.descripcion = drd.IsDBNull(posDescripcion) ? "" : drd.GetString(posDescripcion);
                                lista.Add(oCategoriaClS);
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


        public List<CategoriaCLS> FiltrarCategoria(string nombreCategoria)
        {
            List<CategoriaCLS> lista = null;

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    //llamar procedimineto
                    using (SqlCommand cmd = new SqlCommand("uspFiltrarCategoria", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombre", nombreCategoria);
                        SqlDataReader drd = cmd.ExecuteReader();
                        if (drd != null)
                        {
                            lista = new List<CategoriaCLS>();
                            CategoriaCLS oCategoria;
                            int posId = drd.GetOrdinal("IIDCATEGORIA");
                            int posNombre = drd.GetOrdinal("NOMBRE");
                            int posDescripcion = drd.GetOrdinal("DESCRIPCION");
                            while (drd.Read())
                            {
                                oCategoria = new CategoriaCLS();
                                oCategoria.id = drd.IsDBNull(posId) ? 0 : drd.GetInt32(posId);
                                oCategoria.nombre = drd.IsDBNull(posNombre) ? "" : drd.GetString(posNombre);
                                oCategoria.descripcion = drd.IsDBNull(posDescripcion) ? "" : drd.GetString(posDescripcion);
                                lista.Add(oCategoria);
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


        public int GuardarCategoria(CategoriaCLS oCategoria)
        {
            //crear variable error
            int rtpa = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspGuardarCategoria", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", oCategoria.id);
                        cmd.Parameters.AddWithValue("@nombre", oCategoria.nombre);
                        cmd.Parameters.AddWithValue("@descripcion", oCategoria.descripcion);
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

        public CategoriaCLS RecuperarCategoria(int id)
        {
            CategoriaCLS oCategoria = null;

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    //llamar procedimineto
                    using (SqlCommand cmd = new SqlCommand("uspRecuperarCategoria", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", id);
                        SqlDataReader drd = cmd.ExecuteReader();
                        if (drd != null)
                        {
                            int posId = drd.GetOrdinal("IIDCATEGORIA");
                            int posNombre = drd.GetOrdinal("NOMBRE");
                            int posDescripcion = drd.GetOrdinal("DESCRIPCION");
                            while (drd.Read())
                            {
                                oCategoria = new CategoriaCLS();
                                oCategoria.id = drd.IsDBNull(posId) ? 0 : drd.GetInt32(posId);
                                oCategoria.nombre = drd.IsDBNull(posNombre) ? "" : drd.GetString(posNombre);
                                oCategoria.descripcion = drd.IsDBNull(posDescripcion) ? "" : drd.GetString(posDescripcion);
                            }
                        }
                    }
                    cn.Close();
                }
                catch (Exception ex)
                {
                    oCategoria = null;
                    cn.Close();
                }

            }
            return oCategoria;
        }

        public int EliminarCategoria(int id)
        {
            //crear variable error
            int rtpa = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspEliminarCategoria", cn))
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
