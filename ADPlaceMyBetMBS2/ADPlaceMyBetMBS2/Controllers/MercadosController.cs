using ADPlaceMyBetMBS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ADPlaceMyBetMBS.Controllers
{
    public class MercadosController : ApiController
    {

            // GET: api/Mercados
            public IEnumerable<Mercados> Get()
            {
                var repo = new MercadosRepository();
                List<Mercados> mercados = repo.retrieve();
                return mercados;
            }

             // GET: api/Mercados?usuario=valor1&idMercado=valor2
            public IEnumerable<MercadosUsuario> GetByUsuario(string usuario, int idMercado)
             {
            var repo = new MercadosRepository();
            List<MercadosUsuario> mercados = repo.retrieveByUsuario(usuario, idMercado);
            return mercados;
             }

            // POST: api/Mercados
            public void Post([FromBody] string value)
             {
             }

            // PUT: api/Mercados/5
            public void Put(int id, [FromBody] string value)
            {
            }

            // DELETE: api/Mercados/5
            public void Delete(int id)
            {
            }
        }
}