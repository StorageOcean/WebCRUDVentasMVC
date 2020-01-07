using appVentas.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace appVentas.DataAccess
{
    public class ProductoDA
    {
        private readonly string _connectionString;

        public ProductoDA()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public List<ProductoBO> GetAllProductos()
        {
            List<ProductoBO> lstProducto = new List<ProductoBO>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("uspGetAllProductos", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductoBO productoBO = new ProductoBO();
                    productoBO.CodProd = reader["COD_PROD"].ToString();
                    productoBO.NomProd = reader["NOM_PROD"].ToString();
                    productoBO.CodGrup = reader["COD_GRUP"].ToString();
                    productoBO.CodLin = reader["COD_LIN"].ToString();
                    productoBO.Marca = reader["MARCA"].ToString();
                    productoBO.CosPromC = Convert.ToDecimal(reader["COS_PROM_C"]);
                    productoBO.PrecioVta = Convert.ToDecimal(reader["PRECIO_VTA"]);
                    lstProducto.Add(productoBO);
                }
                connection.Close();
                return lstProducto;
            }
        }

        public ProductoBO GetProductoById(ProductoBO producto)
        {
            ProductoBO productoBO = new ProductoBO();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("uspGetByIdProducto", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@COD_PROD", SqlDbType.VarChar, 25, "COD_PROD").Value = producto.CodProd;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    productoBO.CodProd = reader["COD_PROD"].ToString();
                    productoBO.NomProd = reader["NOM_PROD"].ToString();
                    productoBO.CodGrup = reader["COD_GRUP"].ToString();
                    productoBO.CodLin = reader["COD_LIN"].ToString();
                    productoBO.Marca = reader["MARCA"].ToString();
                    productoBO.CosPromC = Convert.ToDecimal(reader["COS_PROM_C"]);
                    productoBO.PrecioVta = Convert.ToDecimal(reader["PRECIO_VTA"]);
                }
                connection.Close();
                return productoBO;
            }
        }

        public bool InsertProducto(ProductoBO producto)
        {
            bool boolRegistrado;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("uspInsertProducto", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@COD_PROD", SqlDbType.VarChar).Value = producto.CodProd;
                cmd.Parameters.Add("@NOM_PROD", SqlDbType.VarChar).Value = producto.NomProd;
                cmd.Parameters.Add("@COD_GRUP", SqlDbType.Char).Value = producto.CodGrup;
                cmd.Parameters.Add("@COD_LIN", SqlDbType.Char).Value = producto.CodLin;
                cmd.Parameters.Add("@MARCA", SqlDbType.VarChar).Value = producto.Marca;
                cmd.Parameters.Add("@COS_PROM_C", SqlDbType.Money).Value = producto.CosPromC;
                cmd.Parameters.Add("@PRECIO_VTA", SqlDbType.Money).Value = producto.PrecioVta;
                connection.Open();
                boolRegistrado = cmd.ExecuteNonQuery() != 0;
                connection.Close();
                return boolRegistrado;
            }
        }

        public bool UpdateProducto(ProductoBO producto)
        {
            bool boolActualizado;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("uspUpdateProducto", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@COD_PROD", SqlDbType.VarChar).Value = producto.CodProd;
                cmd.Parameters.Add("@NOM_PROD", SqlDbType.VarChar).Value = producto.NomProd;
                cmd.Parameters.Add("@COD_GRUP", SqlDbType.Char).Value = producto.CodGrup;
                cmd.Parameters.Add("@COD_LIN", SqlDbType.Char).Value = producto.CodLin;
                cmd.Parameters.Add("@MARCA", SqlDbType.VarChar).Value = producto.Marca;
                cmd.Parameters.Add("@COS_PROM_C", SqlDbType.Money).Value = producto.CosPromC;
                cmd.Parameters.Add("@PRECIO_VTA", SqlDbType.Money).Value = producto.PrecioVta;
                connection.Open();
                boolActualizado = cmd.ExecuteNonQuery() != 0;
                connection.Close();
                return boolActualizado;
            }
        }

        public bool DeleteProducto(ProductoBO producto)
        {
            bool boolEliminado;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("uspDeleteProducto", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@COD_PROD", SqlDbType.VarChar).Value = producto.CodProd;
                connection.Open();
                boolEliminado = cmd.ExecuteNonQuery() != 0;
                connection.Close();
                return boolEliminado;
            }
        }

    }
}
