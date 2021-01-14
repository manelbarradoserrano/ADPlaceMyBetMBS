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

        internal List<ApuestasUsuario> retrieveByUsuario(string usuario, double tipoMercado)
        {
            MySqlConnection con = Connect();
            MySqlCommand com = con.CreateCommand();
            com.CommandText = "Select * from apuestas where usuario = @A and tipoMercado = @A2";
            com.Parameters.AddWithValue("@A", usuario);
            com.Parameters.AddWithValue("@A2", tipoMercado);

            try
            {
                con.Open();
                MySqlDataReader reader = com.ExecuteReader();

                List<ApuestasUsuario> apuestasU = new List<ApuestasUsuario>();
                while (reader.Read())
                {

                    ApuestasUsuario aU1 = new ApuestasUsuario(reader.GetString(7), reader.GetDouble(2), reader.GetInt32(1), reader.GetString(3), reader.GetDouble(4), reader.GetDouble(5));
                    apuestasU.Add(aU1);
                }
                con.Close();
                return apuestasU;
            }
            catch (Exception)
            {
                Debug.WriteLine("No se ha podido conectar a la base de datos.");
                return null;
            }
        }
    }
}