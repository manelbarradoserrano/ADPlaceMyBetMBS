using ADPlaceMyBetMBS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ADPlaceMyBetMBS.Controllers
{
    public class ApuestasController : ApiController
    {
        // GET: api/Apuestas
        public IEnumerable<Apuestas> Get()
        {
            var repo = new ApuestasRepository();
            List<Apuestas> apuestas = repo.retrieve();
            return apuestas;
        }

        // GET api/Apuestas/5
        public IEnumerable<Apuestas> GetByCuota(double cuota, double cuotaMax)
        {
            var repo = new ApuestasRepository();
            List<Apuestas> apuestas = repo.retrieveByCuota(cuota, cuotaMax);
            return apuestas;
        }

        // POST: api/Apuestas
        //[Authorize(Roles = "Standard")]
        public void Post([FromBody] Apuestas apuesta)
        {
            var repository = new ApuestasRepository();
            repository.Save(apuesta);

        }

        // PUT: api/Apuestas/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Apuestas/5
        public void Delete(int id)
        {
        }
    }
}