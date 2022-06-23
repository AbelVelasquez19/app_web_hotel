using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace CapaDatos
{
    public class ProductoDAL:CadenaDAL
    {
        public List<ProductoCLS> ListaProducto()
        {
            List<ProductoCLS> lista = null;

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    //llamar procedimineto
                    using (SqlCommand cmd = new SqlCommand("uspListarProductos", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader drd = cmd.ExecuteReader();
                        if (drd != null)
                        {
                            lista = new List<ProductoCLS>();
                            ProductoCLS oProductoCLS;
                            int posId = drd.GetOrdinal("IIDPRODUCTO");
                            int posCategoria = drd.GetOrdinal("CATEGORIA");
                            int posNombreMarca = drd.GetOrdinal("NOMBREMARCA");
                            int posNombre = drd.GetOrdinal("NOMBRE");
                            int posPrecioVenta = drd.GetOrdinal("PRECIOVENTA");
                            int posStock = drd.GetOrdinal("STOCK");
                            while (drd.Read())
                            {
                                oProductoCLS = new ProductoCLS();
                                oProductoCLS.iidproducto = drd.IsDBNull(posId) ? 0 : drd.GetInt32(posId);
                                oProductoCLS.nombrecategoria = drd.IsDBNull(posCategoria) ? "" : drd.GetString(posCategoria).ToUpper();
                                oProductoCLS.nombremarca = drd.IsDBNull(posNombreMarca) ? "" : drd.GetString(posNombreMarca).ToUpper();
                                oProductoCLS.nombre = drd.IsDBNull(posNombre) ? "" : drd.GetString(posNombre).ToUpper();
                                oProductoCLS.precio = drd.IsDBNull(posPrecioVenta) ? 0 : drd.GetDecimal(posPrecioVenta);
                                oProductoCLS.stock= drd.IsDBNull(posStock) ? 0 : drd.GetInt32(posStock);
                                oProductoCLS.denominacion = drd.IsDBNull(posStock) ? "" : (drd.GetInt32(posStock) > 50 ? "alto" : "bajo");
                                lista.Add(oProductoCLS);
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
        public List<ProductoCLS> FiltrarProductoPorNombre(string nombreProducto)
        {
            List<ProductoCLS> lista = null;

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    //llamar procedimineto
                    using (SqlCommand cmd = new SqlCommand("uspFiltrarProductos", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombre", nombreProducto);
                        SqlDataReader drd = cmd.ExecuteReader();
                        if (drd != null)
                        {
                            lista = new List<ProductoCLS>();
                            ProductoCLS oProductoCLS;
                            int posId = drd.GetOrdinal("IIDPRODUCTO");
                            int posCategoria = drd.GetOrdinal("CATEGORIA");
                            int posNombreMarca = drd.GetOrdinal("NOMBREMARCA");
                            int posNombre = drd.GetOrdinal("NOMBRE");
                            int posPrecioVenta = drd.GetOrdinal("PRECIOVENTA");
                            int posStock = drd.GetOrdinal("STOCK");
                            while (drd.Read())
                            {
                                oProductoCLS = new ProductoCLS();
                                oProductoCLS.iidproducto = drd.IsDBNull(posId) ? 0 : drd.GetInt32(posId);
                                oProductoCLS.nombrecategoria = drd.IsDBNull(posCategoria) ? "" : drd.GetString(posCategoria).ToUpper();
                                oProductoCLS.nombremarca = drd.IsDBNull(posNombreMarca) ? "" : drd.GetString(posNombreMarca).ToUpper();
                                oProductoCLS.nombre = drd.IsDBNull(posNombre) ? "" : drd.GetString(posNombre).ToUpper();
                                oProductoCLS.precio = drd.IsDBNull(posPrecioVenta) ? 0 : drd.GetDecimal(posPrecioVenta);
                                oProductoCLS.stock = drd.IsDBNull(posStock) ? 0 : drd.GetInt32(posStock);
                                oProductoCLS.denominacion = drd.IsDBNull(posStock) ? "" : (drd.GetInt32(posStock) > 50 ? "alto" : "bajo");
                                lista.Add(oProductoCLS);
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
    }
}
