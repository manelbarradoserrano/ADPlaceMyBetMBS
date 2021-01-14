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
        public Mercados(string overUnder, double tipoMercado, double cuotaOver, double cuotaUnder, double dineroOver, double dineroUnder, int idEvento)
        {
            this.overUnder = overUnder;
            this.tipoMercado = tipoMercado;
            this.cuotaOver = cuotaOver;
            this.cuotaUnder = cuotaUnder;
            this.dineroOver = dineroOver;
            this.dineroUnder = dineroUnder;
            this.idEvento = idEvento;
        }

        public string overUnder { get; set; }
        public double tipoMercado { get; set; }
        public double cuotaOver { get; set; }
        public double cuotaUnder { get; set; }
        public double dineroOver { get; set; }
        public double dineroUnder { get; set; }
        public int idEvento { get; set; }

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
}
