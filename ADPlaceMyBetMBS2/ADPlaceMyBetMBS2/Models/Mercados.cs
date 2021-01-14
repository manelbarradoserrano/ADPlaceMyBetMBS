using ADPlaceMyBetMBS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace ADPlaceMyBetMBS.Models
{
    public class Mercados
    {
        public Mercados(int idMercado, int idEvento, double tipoMercado, double cuotaOver, double cuotaUnder, double dineroOver, double dineroUnder)
        {
            this.idMercado = idMercado;
            this.idEvento = idEvento;
            this.tipoMercado = tipoMercado;
            this.cuotaOver = cuotaOver;
            this.cuotaUnder = cuotaUnder;
            this.dineroOver = dineroOver;
            this.dineroUnder = dineroUnder;
            
        }

        public int idMercado { get; set; }
        public int idEvento { get; set; }
        public double tipoMercado { get; set; }
        public double cuotaOver { get; set; }
        public double cuotaUnder { get; set; }
        public double dineroOver { get; set; }
        public double dineroUnder { get; set; }
        

    }

    public class MercadosDTO
    {
        public MercadosDTO(double tipoMercado, double cuotaOver, double cuotaUnder)
        {
            this.tipoMercado = tipoMercado;
            this.cuotaOver = cuotaOver;
            this.cuotaUnder = cuotaUnder;
        }

        public double tipoMercado { get; set; }
        public double cuotaOver { get; set; }
        public double cuotaUnder { get; set; }
    }

    public class MercadosUsuario
    {
        public MercadosUsuario(double tipoMercado, string tipoApuesta, double cuota, double dineroApostado)
        {
            this.tipoMercado = tipoMercado;
            this.tipoApuesta = tipoApuesta;
            this.cuota = cuota;
            this.dineroApostado = dineroApostado;
        }

        public double tipoMercado { get; set; }
        public string tipoApuesta { get; set; }
        public double cuota { get; set; }
        public double dineroApostado { get; set; }
    }
}
