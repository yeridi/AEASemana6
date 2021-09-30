using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Entity;
namespace Data
{
    public class DProducto
    {
        public List<Producto> Listar()
        {
            string commandText = "USP_GetProductos";
            List<Producto> productos = new List<Producto>();

            try
            {
                using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.Connection, commandText,
                    CommandType.StoredProcedure))
                {
                    while (reader.Read())
                    {
                        productos.Add(new Producto
                        {
                            idproducto = reader["idproducto"] != null ? Convert.ToInt32(reader["idproducto"]) : 0,
                            nombreProducto = reader["nombreProducto"] != null ? reader["nombreProducto"].ToString() : "",
                            idProveedor = reader["idProveedor"] != null ? Convert.ToInt32(reader["idProveedor"]) : 0,
                            idCategoria = reader["idCategoria"] != null ? Convert.ToInt32(reader["idCategoria"]) : 0,
                            cantidadPorUnidad = reader["cantidadPorUnidad"] != null ? reader["cantidadPorUnidad"].ToString() : "",
                            precioUnidad = reader["precioUnidad"] != null ? Convert.ToDouble(reader["precioUnidad"]) : 0,
                            unidadesEnExistencia = reader["unidadesEnExistencia"] != null ? Convert.ToInt32(reader["unidadesEnExistencia"]) : 0,
                            unidadesEnPedido = reader["unidadesEnPedido"] != null ? Convert.ToInt32(reader["unidadesEnPedido"]) : 0,
                            nivelNuevoPedido = reader["nivelNuevoPedido"] != null ? Convert.ToInt32(reader["nivelNuevoPedido"]) : 0,
                            suspendido = reader["suspendido"] != null ? int.Parse(reader["suspendido"].ToString()) : 0,
                            categoriaProducto = reader["categoriaProducto"] != null ? reader["categoriaProducto"].ToString() : ""
                        }
                        );
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error on file DProducto: "+ex.ToString());
                throw;
            }
            return productos;
        }

        public void Insertar(Producto producto)
        {
            SqlParameter[] parameters = new SqlParameter[10];
            string comandText = "USP_InsertProducto";
            try
            {
                parameters[0] = new SqlParameter("@nombreProducto", SqlDbType.VarChar);
                parameters[0].Value = producto.nombreProducto;
                parameters[1] = new SqlParameter("@idProveedor", SqlDbType.Int); ;
                parameters[1].Value = producto.idProveedor;
                parameters[2] = new SqlParameter("@idCategoria", SqlDbType.Int); ;
                parameters[2].Value = producto.idCategoria;
                parameters[3] = new SqlParameter("@cantidadPorUnidad", SqlDbType.VarChar) ;
                parameters[3].Value = producto.cantidadPorUnidad;
                parameters[4] = new SqlParameter("@precioUnidad", SqlDbType.Decimal) ;
                parameters[4].Value = producto.precioUnidad;
                parameters[5] = new SqlParameter("@unidadesEnExistencia", SqlDbType.SmallInt); ;
                parameters[5].Value = producto.unidadesEnExistencia;
                parameters[6] = new SqlParameter("@unidadesEnPedido", SqlDbType.SmallInt); ;
                parameters[6].Value = producto.unidadesEnPedido;
                parameters[7] = new SqlParameter("@nivelNuevoPedido", SqlDbType.SmallInt) ;
                parameters[7].Value = producto.nivelNuevoPedido;
                parameters[8] = new SqlParameter("@suspendido", SqlDbType.SmallInt); 
                parameters[8].Value = producto.suspendido;
                parameters[9] = new SqlParameter("@categoriaProducto", SqlDbType.VarChar); ;
                parameters[9].Value = producto.categoriaProducto;
                SqlHelper.ExecuteNonQuery(SqlHelper.Connection, comandText, CommandType.StoredProcedure, parameters);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error on file DProducto: " + ex.ToString());
                throw ex;
            }
        }

        public void Actualizar(Producto producto)
        {
            SqlParameter[] parameters = new SqlParameter[11];
            string comandText = "USP_UpdateProducto";
            try
            {
                parameters[0] = new SqlParameter("@idproducto", SqlDbType.VarChar);
                parameters[0].Value = producto.idproducto;
                parameters[1] = new SqlParameter("@nombreProducto", SqlDbType.VarChar);
                parameters[1].Value = producto.nombreProducto;
                parameters[2] = new SqlParameter("@idProveedor", SqlDbType.Int); ;
                parameters[2].Value = producto.idProveedor;
                parameters[3] = new SqlParameter("@idCategoria", SqlDbType.Int); ;
                parameters[3].Value = producto.idCategoria;
                parameters[4] = new SqlParameter("@cantidadPorUnidad", SqlDbType.VarChar);
                parameters[4].Value = producto.cantidadPorUnidad;
                parameters[5] = new SqlParameter("@precioUnidad", SqlDbType.Decimal);
                parameters[5].Value = producto.precioUnidad;
                parameters[6] = new SqlParameter("@unidadesEnExistencia", SqlDbType.SmallInt); ;
                parameters[6].Value = producto.unidadesEnExistencia;
                parameters[7] = new SqlParameter("@unidadesEnPedido", SqlDbType.SmallInt); ;
                parameters[7].Value = producto.unidadesEnPedido;
                parameters[8] = new SqlParameter("@nivelNuevoPedido", SqlDbType.SmallInt);
                parameters[8].Value = producto.nivelNuevoPedido;
                parameters[9] = new SqlParameter("@suspendido", SqlDbType.SmallInt);
                parameters[9].Value = producto.suspendido;
                parameters[10] = new SqlParameter("@categoriaProducto", SqlDbType.VarChar); ;
                parameters[10].Value = producto.categoriaProducto;
                SqlHelper.ExecuteNonQuery(SqlHelper.Connection, comandText, CommandType.StoredProcedure, parameters);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error on file DProducto: " + ex.ToString());
                throw ex;
            }
        }

        public void Eliminar(int IdProducto)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            string comandText = "USP_DeleteProducto";
            try 
            { 
                parameters[0] = new SqlParameter("@idproducto", SqlDbType.Int);
                parameters[0].Value = IdProducto;
                SqlHelper.ExecuteNonQuery(SqlHelper.Connection, comandText, CommandType.StoredProcedure, parameters);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error on file DProducto: " + ex.ToString());
                throw ex;
            }
        }
    }
}
