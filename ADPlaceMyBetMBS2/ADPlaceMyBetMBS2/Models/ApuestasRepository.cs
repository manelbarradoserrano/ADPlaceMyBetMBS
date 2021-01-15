using ADPlaceMyBetMBS.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http;
using System.Globalization;

namespace ADPlaceMyBetMBS.Models
{
    public class ApuestasRepository
    {
        private MySqlConnection Connect()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=placemybet;SslMode=none";
            MySqlConnection con = new MySqlConnection(connectionString);
            return con;
        }
        internal List<Apuestas> retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand com = con.CreateCommand();
            com.CommandText = "Select * from apuestas";
            try
            {
                con.Open();
                MySqlDataReader reader = com.ExecuteReader();
                List<Apuestas> apuesta = new List<Apuestas>();
                while (reader.Read())
                {
                    Apuestas a1 = new Apuestas(reader.GetInt32(0), reader.GetInt32(1), reader.GetDouble(2), reader.GetString(3),  reader.GetDouble(4), reader.GetDouble(5), reader.GetDateTime(6), reader.GetString(7));
                    apuesta.Add(a1);
                }
                con.Close();
                return apuesta;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        internal List<ApuestasDTO> retrieveDTO()
        {
            MySqlConnection con = Connect();
            MySqlCommand com = con.CreateCommand();
            com.CommandText = "Select * from apuestas";
            try
            {
                con.Open();
                MySqlDataReader reader = com.ExecuteReader();
                List<ApuestasDTO> apuestaDTO = new List<ApuestasDTO>();
                while (reader.Read())
                {
                    ApuestasDTO a1 = new ApuestasDTO(reader.GetString(3), reader.GetDouble(2), reader.GetDouble(4), reader.GetDouble(5), reader.GetMySqlDateTime(6).ToString(), reader.GetString(7));
                    apuestaDTO.Add(a1);
                }
                con.Close();
                return apuestaDTO;
            }
            catch (Exception)
            {
                Debug.WriteLine("No se ha podido conectar a la base de datos.");
                return null;
            }
        }

        internal void Save(Apuestas a)
        {
            CultureInfo culInfo = new System.Globalization.CultureInfo("es-ES");

            culInfo.NumberFormat.NumberDecimalSeparator = ".";

            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            culInfo.NumberFormat.PercentDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = culInfo;

            MySqlConnection con = Connect();
            MySqlCommand com = con.CreateCommand();
            MySqlCommand comandocuotas = con.CreateCommand();
            MySqlCommand cambiardinero = con.CreateCommand();

            DateTime dt = DateTime.Now;
            string fecha = dt.ToString("yyyyMMddHHmmss");
            double over = crearDineroOver(a.idMercado);
            double under = crearDineroUnder(a.idMercado);
            double probunder = calcularProbUnder(over, under);
            double probover = calcularProbOver(over, under);

            double cuota;
            if (a.tipoApuesta == "over")
            {
                Debug.WriteLine("Antes de la cuota " + a.idMercado);
                cuota = (double)crearCuotaOver(a.idMercado);
                Debug.WriteLine("Despues de cuota" + cuota);
                Debug.WriteLine("El dinero es " + a.dineroApostado);

                double calccover = calculoCuota(probover);
                double calcunder = calculoCuota(probunder);
                calcunder = Math.Round(calcunder, 2);
                calccover = Math.Round(calccover, 2);

                com.CommandText = "INSERT INTO `apuestas` VALUES ('" + a.idMercado + "','" + a.idEvento + "','" + a.tipoMercado + "','" + a.tipoApuesta + "','" + cuota + "','" + a.dineroApostado + "','" + fecha + "','" + a.usuario + "');'";
                cambiardinero.CommandText = "UPDATE mercados SET dineroOver = dineroOver +" + a.dineroApostado + "WHERE idMercado =" + a.idMercado + ";";
                comandocuotas.CommandText = "UPDATE `mercados` SET `cuotaOver`=" + calccover + "WHERE idMercado =" + a.idMercado + ";";
            }
            else
            {
                Debug.WriteLine("Antes de la cuota " + a.idMercado);
                cuota = (double)crearCuotaUnder(a.idMercado);
                Debug.WriteLine("Despues de cuota" + cuota);
                Debug.WriteLine("El dinero es " + a.dineroApostado);

                double calculoover = calculoCuota(probover);
                double calculounder = calculoCuota(probunder);
                calculounder = Math.Round(calculounder, 2);
                calculoover = Math.Round(calculoover, 2);

                com.CommandText = "INSERT INTO `apuestas` VALUES ('" + a.idMercado + "','" + a.idEvento + "','" + a.tipoMercado + "','" + a.tipoApuesta + "','" + cuota + "','" + a.dineroApostado + "','" + fecha + "','" + a.usuario + "');'";
                cambiardinero.CommandText = "UPDATE `mercados` SET `dineroUnder`= dineroUnder + " + a.dineroApostado + "WHERE idMercado=" + a.idMercado + ";";
                comandocuotas.CommandText = "UPDATE `mercados` SET `cuotaUnder`=" + calculounder + "WHERE idMercado=" + a.idMercado + ";";
            }

            Debug.WriteLine("Comando: " + com.CommandText);

            try
            {
                con.Open();

                com.ExecuteNonQuery();
                cambiardinero.ExecuteNonQuery();
                comandocuotas.ExecuteNonQuery();

                con.Close();

            }
            catch (MySqlException e)
            {
                Debug.WriteLine(e);

            }
        }

        internal object crearCuotaOver(int mercado)
        {
            MySqlConnection con = Connect();
            MySqlCommand com = con.CreateCommand();
            com.CommandText = string.Format("SELECT cuotaOver FROM mercados WHERE idMercado=" + mercado + ";");
            Debug.WriteLine("El comando es " + com.CommandText);

            con.Open();
            double cuota = Convert.ToDouble(com.ExecuteScalar());
            Debug.WriteLine("Y vale " + cuota);

            return cuota;
        }

        internal object crearCuotaUnder(int mercado)
        {
            MySqlConnection con = Connect();
            MySqlCommand com = con.CreateCommand();
            com.CommandText = string.Format("SELECT cuotaUnder FROM mercados WHERE idMercados=" + mercado + ";");

            con.Open();
            double cuota = Convert.ToDouble(com.ExecuteScalar());
            Debug.WriteLine("Y vale" + cuota);
            con.Close();

            return cuota;
        }

        internal double crearDineroOver(int mercado)
        {
            MySqlConnection con = Connect();
            MySqlCommand com = con.CreateCommand();
            com.CommandText = string.Format("SELECT dineroOver FROM mercados WHERE idMercado = " + mercado + ";");
            Debug.WriteLine("El comando es " + com.CommandText);

            con.Open();
            double prob = Convert.ToDouble(com.ExecuteScalar());

            con.Close();

            return prob;
        }

        internal double calcularProbOver(double dineroOver, double dineroUnder)
        {
            double probabilidad = dineroOver / (dineroOver + dineroUnder);

            return probabilidad;
        }

        internal double crearDineroUnder(int mercado)
        {
            MySqlConnection con = Connect();
            MySqlCommand com = con.CreateCommand();
            com.CommandText = string.Format("SELECT dineroUnder FROM mercados WHERE idMercado = " + mercado + ";");
            Debug.WriteLine("El comando es " + com.CommandText);

            con.Open();
            double prob = Convert.ToDouble(com.ExecuteScalar());

            con.Close();

            return prob;
        }

        internal double calcularProbUnder(double dineroOver, double dineroUnder)
        {
            double probabilidad = dineroUnder / (dineroOver + dineroUnder);

            return probabilidad;
        }

        internal double calculoCuota(double probabilidad)
        {
            double cuota = (1 / probabilidad) * 0.95;

            return cuota;
        }


        //Examen Ej1 Retrieve Apuestas by Cuota
        internal List<Apuestas> retrieveByCuota(double cuotaMin, double cuotaMax)
        {
            MySqlConnection con = Connect();
            MySqlCommand com = con.CreateCommand();
            com.CommandText = "Select * from apuestas where cuota >= @A and cuota <= @A2";
            com.Parameters.AddWithValue("@A", cuotaMin);
            com.Parameters.AddWithValue("@A2", cuotaMax);

            try
            {
                con.Open();
                MySqlDataReader reader = com.ExecuteReader();

                List<Apuestas> apuestasC = new List<Apuestas>();
                while (reader.Read())
                {                                                                                          

                    Apuestas aC1 = new Apuestas(reader.GetInt32(0), reader.GetInt32(1), reader.GetDouble(2), reader.GetString(3), reader.GetDouble(4), reader.GetDouble(5), reader.GetDateTime(6), reader.GetString(7));
                    apuestasC.Add(aC1);
                }
                con.Close();
                return apuestasC;
            }
            catch (Exception)
            {
                Debug.WriteLine("No se ha podido conectar a la base de datos.");
                return null;
            }
        }

        //Examen Ej2 Retrieve Apuestas by Mercado
        internal List<Apuestas> retrieveByMercado(int idMercado, double dineroApostado)
        {
            MySqlConnection con = Connect();
            MySqlCommand com = con.CreateCommand();
            com.CommandText = "Select * from apuestas where idMercado= @A and dineroApostado >= @A2";
            com.Parameters.AddWithValue("@A", idMercado);
            com.Parameters.AddWithValue("@A2", dineroApostado);

            try
            {
                con.Open();
                MySqlDataReader reader = com.ExecuteReader();

                List<Apuestas> apuestasM = new List<Apuestas>();
                while (reader.Read())
                {

                    Apuestas aC1 = new Apuestas(reader.GetInt32(0), reader.GetInt32(1), reader.GetDouble(2), reader.GetString(3), reader.GetDouble(4), reader.GetDouble(5), reader.GetDateTime(6), reader.GetString(7));
                    apuestasM.Add(aC1);
                }
                con.Close();
                return apuestasM;
            }
            catch (Exception)
            {
                Debug.WriteLine("No se ha podido conectar a la base de datos.");
                return null;
            }
        }

    }
}