using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WebServiceRestAndroid.Models
{
    public class PacientesManager
    {
        private static string _stringConnection;
        public PacientesManager()
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["MySqlConnectionString_local"];
            _stringConnection = settings.ConnectionString;
        }

        public bool InsertPaciente(Paciente p)
        {
            MySqlConnection con = new MySqlConnection(_stringConnection);
            con.Open();

            string sql = "INSERT INTO paciente(nombre, edad, sexo, tipoSangre, peso, altura) VALUES (@nombre, @edad, @sexo, @tipoSangre, @peso, @altura)";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("nombre", p.Nombre);
            cmd.Parameters.AddWithValue("edad", p.Edad);
            cmd.Parameters.AddWithValue("sexo", p.Sexo);
            cmd.Parameters.AddWithValue("tipoSangre", p.TipoSangre);
            cmd.Parameters.AddWithValue("peso", p.Peso);
            cmd.Parameters.AddWithValue("altura", p.Altura);

            int res = cmd.ExecuteNonQuery();
            con.Close();

            return (res == 1);
        }
    }
}