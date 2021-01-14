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
                    Eventos e1 = new Eventos(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
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
    }
}