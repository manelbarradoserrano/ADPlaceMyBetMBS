using ADPlaceMyBetMBS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace ADPlaceMyBetMBS.Models
{
    public class Eventos
    {
        public Eventos(int idApuesta, string eqLocal, string eqVisitante, DateTime fechaApuesta)
        {
            this.idApuesta = idApuesta;
            this.eqLocal = eqLocal;
            this.eqVisitante = eqVisitante;
            this.fechaApuesta = fechaApuesta;
        }

        public int idApuesta { get; set; }
        public string eqLocal { get; set; }
        public string eqVisitante { get; set; }
        public DateTime fechaApuesta { get; set; }
    }

    public class EventosDTO
    {
        public EventosDTO(string eqLocal, string eqVisitante, string fechaApuesta)
        {

            this.eqLocal = eqLocal;
            this.eqVisitante = eqVisitante;
            this.fechaApuesta = fechaApuesta;
        }

        public string eqLocal { get; set; }
        public string eqVisitante { get; set; }
        public string fechaApuesta { get; set; }
    }
}
