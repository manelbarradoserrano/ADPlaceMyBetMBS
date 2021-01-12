using ADPlaceMyBetMBS.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace ADPlaceMyBetMBS.Models
{
    public class UsuariosRepository
    {
          
            private MySqlConnection Connect()
            {
                string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=placemybet;SslMode=none";
                MySqlConnection con = new MySqlConnection(connectionString);
                return con;
            }
            internal List<Usuarios> retrieve()
            {
                MySqlConnection con = Connect();
                MySqlCommand com = con.CreateCommand();
                com.CommandText = "Select * from usuarios";
                try
                {
                    con.Open();
                    MySqlDataReader reader = com.ExecuteReader();
                    List<Usuarios> usuario = new List<Usuarios>();
                    while (reader.Read())
                    {
                        Usuarios u1 = new Usuarios(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));
                        usuario.Add(u1);
                    }
                    con.Close();
                    return usuario;
                }
                catch (Exception)
                {
                    Debug.WriteLine("No se ha podido conectar a la base de datos.");
                    return null;
                }
            }
        }
}