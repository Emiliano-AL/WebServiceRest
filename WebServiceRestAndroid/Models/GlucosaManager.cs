using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WebServiceRestAndroid.Models
{
    public class GlucosaManager
    {
        private static string _stringConnection;
        public GlucosaManager()
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["MySqlConnectionString_local"];
            _stringConnection = settings.ConnectionString;
        }

        public bool InsertGlucosa(Glucosa g)
        {
            MySqlConnection con = new MySqlConnection(_stringConnection);
            con.Open();

            string sql = "INSERT INTO glucosa(paciente_id, glucosa, tiempo) VALUES (@paciente_id, @glucosa, @tiempo)";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("paciente_id", g.PacienteId);
            cmd.Parameters.AddWithValue("glucosa", g.CantGlucosa);
            cmd.Parameters.AddWithValue("tiempo", g.Tiempo);

            int res = cmd.ExecuteNonQuery();
            con.Close();

            return (res == 1);
        }
    }
}