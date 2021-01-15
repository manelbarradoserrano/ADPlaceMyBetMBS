using ADPlaceMyBetMBS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
namespace ADPlaceMyBetMBS.Controllers
{
    public class EventosController : ApiController
    {
            // GET: api/Eventos
            public IEnumerable<Eventos> Get()
            {
                var repo = new EventosRepository();
                List<Eventos> eventos = repo.retrieve();
                return eventos;
            }

            // GET: api/Eventos?idEvento=valor1&tipoMercado=valor2
            public IEnumerable<Mercados> GetByEvento(int idEvento, double tipoMercado)
            {
                 var repo = new EventosRepository();
                List<Mercados> mercados = repo.retrieveByEvento(idEvento, tipoMercado);
                return mercados;
            }

        // POST: api/Eventos
        public void Post([FromBody] string value)
            {
            }

            // PUT: api/Eventos/5
            public void Put(int id, [FromBody] string value)
            {
            }

            // DELETE: api/Eventos/5
            public void Delete(int id)
            {
            }
        }
    }