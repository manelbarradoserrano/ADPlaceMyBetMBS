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
    public class MercadosRepository
    {
        private MySqlConnection Connect()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=placemybet;SslMode=none";
            MySqlConnection con = new MySqlConnection(connectionString);
            return con;
        }
        internal List<Mercados> retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand com = con.CreateCommand();
            com.CommandText = "Select * from mercados";
            try
            {
                con.Open();
                MySqlDataReader reader = com.ExecuteReader();
                List<Mercados> mercado = new List<Mercados>();
                while (reader.Read())
                {
                    Mercados m1 = new Mercados(reader.GetDouble(0), reader.GetDouble(1), reader.GetDouble(2), reader.GetDouble(3), reader.GetDouble(4), reader.GetInt32(5));
                    mercado.Add(m1);
                }
                con.Close();
                return mercado;
            }
            catch (Exception)
            {
                Debug.WriteLine("No se ha podido conectar a la base de datos.");
                return null;
            }
        }
    }
}