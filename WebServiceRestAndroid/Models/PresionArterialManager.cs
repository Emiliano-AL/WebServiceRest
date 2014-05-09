using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WebServiceRestAndroid.Models
{
    public class PresionArterialManager
    {
        private static string _stringConnection;
        public PresionArterialManager()
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["MySqlConnectionString_local"];
            _stringConnection = settings.ConnectionString;
        }

        public bool InsertPresion(PresionArterial p)
        {
            MySqlConnection con = new MySqlConnection(_stringConnection);
            con.Open();

            string sql = "INSERT INTO presion_arterial(paciente_id, sistolica, diastolica, brazo, fecha, hora) VALUES (@paciente_id, @sistolica, @diastolica, @brazo, @fecha, @hora)";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("paciente_id", p.PacienteId);
            cmd.Parameters.AddWithValue("sistolica", p.Sistolica);
            cmd.Parameters.AddWithValue("diastolica", p.Diastolica);
            cmd.Parameters.AddWithValue("brazo", p.Brazo);
            cmd.Parameters.AddWithValue("fecha", p.Fecha);
            cmd.Parameters.AddWithValue("hora", p.Hora);

            int res = cmd.ExecuteNonQuery();
            con.Close();

            return (res == 1);
        }

        public PresionArterial GetHistorial(int id_paciente)
        {
            PresionArterial p = null;
            MySqlConnection con = new MySqlConnection(_stringConnection);
            con.Open();
            string sql = "SELECT fecha, hora, diastolica, sistolica, brazo, paciente_id FROM presion_arterial WHERE paciente_id = @id";

            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@id", id_paciente);

            MySqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            if (reader.Read())
            {
                p = new PresionArterial();
                p.Fecha = reader.GetString(0);
                p.Hora = reader.GetString(1);
                p.Diastolica = reader.GetString(2);
                p.Sistolica = reader.GetString(3);
                p.Brazo = reader.GetString(4);
                p.PacienteId = Convert.ToInt32(reader.GetString(5));

            }
            reader.Close();
            return p;
        }
    }
}