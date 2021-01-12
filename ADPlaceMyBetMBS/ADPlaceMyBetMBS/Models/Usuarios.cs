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
}
