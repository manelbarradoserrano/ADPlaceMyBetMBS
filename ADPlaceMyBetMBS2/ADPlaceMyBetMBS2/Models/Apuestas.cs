using ADPlaceMyBetMBS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace ADPlaceMyBetMBS.Models
{
    public class Apuestas
    {
            public Apuestas(int idMercado, int idEvento, double tipoMercado, string tipoApuesta, double cuota, double dineroApostado, DateTime fechaApuesta, string usuario)
            {
                this.idMercado = idMercado;
                this.idEvento = idEvento;
                this.tipoApuesta = tipoApuesta;
                this.tipoMercado = tipoMercado;
                this.cuota = cuota;
                this.dineroApostado = dineroApostado;
                this.fechaApuesta = fechaApuesta;
                this.usuario = usuario;

            }

      

            public int idMercado { get; set; }
            public int idEvento { get; set; }
            public string tipoApuesta { get; set; }
            public double tipoMercado { get; set; }
            public double cuota { get; set; }
            public double dineroApostado { get; set; }
            public DateTime fechaApuesta { get; set; }
            public string usuario { get; set; }
        }

        public class ApuestasDTO
    {
        public ApuestasDTO(string tipoApuesta, double tipoMercado, double cuota, double dineroApostado, string fechaApuesta, string usuario)
        {
           
            this.tipoApuesta = tipoApuesta;
            this.tipoMercado = tipoMercado;
            this.cuota = cuota;
            this.dineroApostado = dineroApostado;
            this.fechaApuesta = fechaApuesta;
            this.usuario = usuario;

        }

        public string tipoApuesta { get; set; }
        public double tipoMercado { get; set; }
        public double cuota { get; set; }
        public double dineroApostado { get; set; }
        public string fechaApuesta { get; set; }
        public string usuario { get; set; }
    }

   
}
