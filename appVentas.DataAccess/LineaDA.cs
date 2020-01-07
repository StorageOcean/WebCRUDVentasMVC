using appVentas.BusinessEntities;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace appVentas.DataAccess
{
    public class LineaDA
    {
        private readonly string _connectionString;

        public LineaDA()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public List<LineaBO> GetAllLineas()
        {
            List<LineaBO> lstLinea = new List<LineaBO>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_uspGetAllLineas", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    LineaBO lineaBO = new LineaBO();
                    lineaBO.CodLin = reader["COD_LIN"].ToString();
                    lineaBO.NomLin = reader["NOM_LIN"].ToString();
                    lstLinea.Add(lineaBO);
                }
                connection.Close();
                return lstLinea;
            }
        }
    }
}

