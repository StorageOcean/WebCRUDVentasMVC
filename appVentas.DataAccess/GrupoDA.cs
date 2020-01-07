using appVentas.BusinessEntities;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace appVentas.DataAccess
{
    public class GrupoDA
    {
        private readonly string _connectionString;

        public GrupoDA()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public List<GrupoBO> GetAllGrupos()
        {
            List<GrupoBO> lstGrupo = new List<GrupoBO>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_uspGetAllGrupos", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    GrupoBO grupoBO = new GrupoBO();
                    grupoBO.CodGrup = reader["COD_GRUP"].ToString();
                    grupoBO.NomGrup = reader["NOM_GRUP"].ToString();
                    lstGrupo.Add(grupoBO);
                }
                connection.Close();
                connection.Dispose();
              
            }
            return lstGrupo;
        }
    }
}
