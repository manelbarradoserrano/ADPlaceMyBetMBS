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
    public class EventosRepository
    {
        private MySqlConnection Connect()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=placemybet;SslMode=none";
            MySqlConnection con = new MySqlConnection(connectionString);
            return con;
        }
        internal List<Eventos> retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand com = con.CreateCommand();
            com.CommandText = "Select * from eventos";
            try
            {
                con.Open();
                MySqlDataReader reader = com.ExecuteReader();
                List<Eventos> evento = new List<Eventos>();
                while (reader.Read())
                {
                    Eventos e1 = new Eventos(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDateTime(3));
                    evento.Add(e1);
                }
                con.Close();
                return evento;
            }
            catch (Exception)
            {
                Debug.WriteLine("No se ha podido conectar a la base de datos.");
                return null;
            }
        }

        internal List<EventosDTO> retrieveDTO()
        {
            MySqlConnection con = Connect();
            MySqlCommand com = con.CreateCommand();
            com.CommandText = "Select * from eventos";
            try
            {
                con.Open();
                MySqlDataReader reader = com.ExecuteReader();
                List<EventosDTO> eventoDTO = new List<EventosDTO>();
                while (reader.Read())
                {
                    EventosDTO e1 = new EventosDTO(reader.GetString(0), reader.GetString(1), reader.GetString(2));
                    eventoDTO.Add(e1);
                }
                con.Close();
                return eventoDTO;
            }
            catch (Exception)
            {
                Debug.WriteLine("No se ha podido conectar a la base de datos.");
                return null;
            }
        }

        internal List<Mercados> retrieveByEvento(int idEvento, double tipoMercado)
        {
            MySqlConnection con = Connect();
            MySqlCommand com = con.CreateCommand();
            com.CommandText = "Select * from mercados where idEvento = @A and tipoMercado = @A2";
            com.Parameters.AddWithValue("@A", idEvento);
            com.Parameters.AddWithValue("@A2", tipoMercado);

            try
            {
                con.Open();
                MySqlDataReader reader = com.ExecuteReader();

                List<Mercados> mercado = new List<Mercados>();
                while (reader.Read())
                {

                    Mercados m1 = new Mercados(reader.GetInt32(0), reader.GetInt32(1), reader.GetDouble(2), reader.GetDouble(3), reader.GetDouble(4), reader.GetDouble(5), reader.GetDouble(6));
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
