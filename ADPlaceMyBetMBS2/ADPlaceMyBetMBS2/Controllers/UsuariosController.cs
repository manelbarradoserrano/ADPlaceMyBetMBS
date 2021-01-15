using ADPlaceMyBetMBS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ADPlaceMyBetMBS.Controllers
{
    public class UsuariosController : ApiController
    { 
            // GET: api/Usuarios
            public IEnumerable<Usuarios> Get()
            {
                var repo = new UsuariosRepository();
                List<Usuarios> usuarios = repo.retrieve();
                return usuarios;
            }

        //GET: api/Usuarios?usuario=valor1&tipoMercado=valor2
         [Authorize(Roles = "Admin")]
        public IEnumerable<ApuestasUsuario> GetByUsuario(string usuario, double tipoMercado)
        {
            var repo = new UsuariosRepository();
            List<ApuestasUsuario> apuestasU = repo.retrieveByUsuario(usuario, tipoMercado);
            return apuestasU;
        }

        // POST: api/Usuarios
        public void Post([FromBody] string value)
            {
            }

            // PUT: api/Usuarios/5
            public void Put(int id, [FromBody] string value)
            {
            }

            // DELETE: api/Usuarios/5
            public void Delete(int id)
            {
            }
        }
}