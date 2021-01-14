using ADPlaceMyBetMBS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ADPlaceMyBetMBS.Models
{
       public class Usuarios
        {
            public Usuarios(string email, string nombre, string apellidos, int edad)
            {
                this.email = email;
                this.nombre = nombre;
                this.apellidos = apellidos;
                this.edad = edad;
            }

            public string email { get; set; }
            public string nombre { get; set; }
            public string apellidos { get; set; }
            public int edad { get; set; }
        }

    public class ApuestasUsuario
    {
        public ApuestasUsuario(string usuario, double tipoMercado, int idEvento, string tipoApuesta, double cuota, double dineroApostado)
        {
            this.usuario = usuario;
            this.tipoMercado = tipoMercado;
            this.idEvento = idEvento;
            this.tipoApuesta = tipoApuesta;
            this.cuota = cuota;
            this.dineroApostado = dineroApostado;

        }

        public string usuario { get; set; }
        public double tipoMercado { get; set; }
        public int idEvento { get; set; }
        public string tipoApuesta { get; set; }
        public double cuota { get; set; }
        public double dineroApostado { get; set; }
    }
}
