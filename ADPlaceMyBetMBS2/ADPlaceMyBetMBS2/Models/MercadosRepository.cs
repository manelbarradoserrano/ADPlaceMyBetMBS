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
                    Mercados m1 = new Mercados(reader.GetInt32(0),reader.GetInt32(1), reader.GetDouble(2), reader.GetDouble(3), reader.GetDouble(4), reader.GetDouble(5), reader.GetDouble(6));
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

        internal List<MercadosDTO> retrieveDTO()
        {
            MySqlConnection con = Connect();
            MySqlCommand com = con.CreateCommand();
            com.CommandText = "Select * from mercados";
            try
            {
                con.Open();
                MySqlDataReader reader = com.ExecuteReader();
                List<MercadosDTO> mercadoDTO = new List<MercadosDTO>();
                while (reader.Read())
                {
                    MercadosDTO m1 = new MercadosDTO(reader.GetDouble(0), reader.GetDouble(1), reader.GetDouble(2));
                    mercadoDTO.Add(m1);
                }
                con.Close();
                return mercadoDTO;
            }
            catch (Exception)
            {
                Debug.WriteLine("No se ha podido conectar a la base de datos.");
                return null;
            }
        }

        internal List<MercadosUsuario> retrieveByUsuario(string usuario, double tipoMercado)
        {
            MySqlConnection con = Connect();
            MySqlCommand com = con.CreateCommand();
            com.CommandText = "Select * from apuestas where usuario = @A and idMercado = @A2";
            com.Parameters.AddWithValue("@A", usuario);
            com.Parameters.AddWithValue("@A2", tipoMercado);

            try
            {
                con.Open();
                MySqlDataReader reader = com.ExecuteReader();

                List<MercadosUsuario> mercado = new List<MercadosUsuario>();
                while (reader.Read())
                {

                    MercadosUsuario m1 = new MercadosUsuario(reader.GetDouble(2), reader.GetString(3), reader.GetDouble(4), reader.GetDouble(5));
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