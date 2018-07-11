using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BoVoyage.Data;
using BoVoyage.Models;

namespace WebApplication1.Controllers
{
    [RoutePrefix("api/Destinations")]
    public class DestinationsController : ApiController
    {
        private BoVoyageDbContext db = new BoVoyageDbContext();

        // GET: api/Destinations
        public IQueryable<Destination> GetDestinations()
        {
            return db.Destinations;
        }

        // GET: api/Destinations/pays
        [Route("{Pays}")]
        [ResponseType(typeof(Destination))]
        public IQueryable<Destination> GetDestination(string pays)
        {
            return db.Destinations.Where(x => x.Pays.Contains(pays));
        }

        // POST: api/Destinations
        [ResponseType(typeof(Destination))]
        public IHttpActionResult PostDestination(Destination destination)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Destinations.Add(destination);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = destination.IdDestination }, destination);
        }

        // DELETE: api/Destinations/5
        [Route("{IdDestination}")]
        [ResponseType(typeof(Destination))]
        public IHttpActionResult DeleteDestination(int IdDestination)
        {
            Destination destination = db.Destinations.Find(IdDestination);
            if (destination == null)
            {
                return NotFound();
            }

            db.Destinations.Remove(destination);
            db.SaveChanges();

            return Ok(destination);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DestinationExists(int id)
        {
            return db.Destinations.Count(e => e.IdDestination == id) > 0;
        }
    }
}