﻿using System;
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
    [RoutePrefix("api/DossierReservations")]
    public class DossierReservationsController : ApiController
    {
        private BoVoyageDbContext db = new BoVoyageDbContext();

        // GET: api/DossierReservations
        public IQueryable<DossierReservation> GetDossiersReservations()
        {
            return db.DossiersReservations;
        }

        // GET: api/DossierReservations/5
        [Route("{IdDossierReservation}")]
        [ResponseType(typeof(DossierReservation))]
        public IHttpActionResult GetDossierReservation(int id)
        {
            DossierReservation dossierReservation = db.DossiersReservations.Find(id);
            if (dossierReservation == null)
            {
                return NotFound();
            }

            return Ok(dossierReservation);
        }

        // PUT: api/DossierReservations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDossierReservation(int id, DossierReservation dossierReservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dossierReservation.IdDossierReservation)
            {
                return BadRequest();
            }

            db.Entry(dossierReservation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DossierReservationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/DossierReservations
        [ResponseType(typeof(DossierReservation))]
        public IHttpActionResult PostDossierReservation(DossierReservation dossierReservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DossiersReservations.Add(dossierReservation);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dossierReservation.IdDossierReservation }, dossierReservation);
        }

        // DELETE: api/DossierReservations/5
        [Route("{IdAgenceVoyage}")]
        [ResponseType(typeof(DossierReservation))]
        public IHttpActionResult DeleteDossierReservation(int id)
        {
            DossierReservation dossierReservation = db.DossiersReservations.Find(id);
            if (dossierReservation == null)
            {
                return NotFound();
            }

            db.DossiersReservations.Remove(dossierReservation);
            db.SaveChanges();

            return Ok(dossierReservation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DossierReservationExists(int id)
        {
            return db.DossiersReservations.Count(e => e.IdDossierReservation == id) > 0;
        }
    }
}