using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WebServiceRestAndroid.Models
{
    public class ClienteManager
    {
        private static string _stringConnection;
        public ClienteManager()
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["MySqlConnectionString_local"];
            _stringConnection = settings.ConnectionString;
        }

        public bool InsertCliente(Cliente c)
        {
            MySqlConnection con = new MySqlConnection(_stringConnection);
            con.Open();

            string sql = "INSERT INTO cliente(nombre, telefono) VALUES (@nombre, @telefono)";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.Add("@nombre", MySqlDbType.VarChar).Value = c.Nombre;
            cmd.Parameters.Add("@telefono", MySqlDbType.VarChar).Value = c.Telefono;

            int res = cmd.ExecuteNonQuery();
            con.Close();

            return (res == 1);
        }

        public bool UpdateCliente(Cliente cli)
        {
            MySqlConnection con = new MySqlConnection(_stringConnection);

            con.Open();

            string sql = "UPDATE cliente SET nombre = @nombre, telefono = @telefono WHERE id = @id";

            MySqlCommand cmd = new MySqlCommand(sql, con);

            cmd.Parameters.Add("@nombre", MySqlDbType.VarChar).Value = cli.Nombre;
            cmd.Parameters.Add("@telefono", MySqlDbType.VarChar).Value = cli.Telefono;
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = cli.Id;

            int res = cmd.ExecuteNonQuery();
            con.Close();
            return (res == 1);
        }

        public Cliente GetCliente(int id)
        {
            Cliente cli = null;
            MySqlConnection con = new MySqlConnection(_stringConnection);
            con.Open();
            string sql = "SELECT nombre, telefono FROM cliente WHERE id = @id";

            MySqlCommand cmd = new MySqlCommand(sql, con);

            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;

            MySqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            if (reader.Read())
            {
                cli = new Cliente();
                cli.Id = id;
                cli.Nombre = reader.GetString(0);
                cli.Telefono = reader.GetString(1);
            }
            reader.Close();
            return cli;
        }

        public bool DeleteCliente(int id)
        {
            MySqlConnection con = new MySqlConnection(_stringConnection);
            con.Open();
            string sql = "DELETE FROM Cliente WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(sql, con);

            cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return (res == 1);
        }

        public List<Cliente> RetrieveAllClientes()
        {
            List<Cliente> lista = new List<Cliente>();
            MySqlConnection con = new MySqlConnection(_stringConnection);
            con.Open();

            string sql = "SELECT id, nombre, telefono FROM cliente";
            MySqlCommand cmd = new MySqlCommand(sql, con);

            MySqlDataReader r = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

            while (r.Read())
            {
                Cliente c = new Cliente();
                c.Id = r.GetInt32(0);
                c.Nombre = r.GetString(1);
                c.Telefono = r.GetString(2);

                lista.Add(c);
            }
            r.Close();
            return lista;
        }
    }
}