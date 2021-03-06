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
    [RoutePrefix("api/AgenceVoyages")]
    public class AgenceVoyagesController : ApiController
    {
        private BoVoyageDbContext db = new BoVoyageDbContext();

        // GET: api/AgenceVoyages
        public IQueryable<AgenceVoyage> GetAgenceVoyages()
        {
            return db.AgenceVoyages;
        }


        //GET: api/AgenceVoyages/nomAgence
        [Route("{nomAgence}")]
        [ResponseType(typeof(AgenceVoyage))]
        public IQueryable<AgenceVoyage> GetAgenceVoyages(string nomAgence)
        {
            return db.AgenceVoyages.Where(x => x.NomAgence.Contains(nomAgence));
        }

        // PUT: api/AgenceVoyages/5
        [Route("{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAgenceVoyage(int id, AgenceVoyage agenceVoyage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != agenceVoyage.IdAgenceVoyage)
            {
                return BadRequest();
            }

            db.Entry(agenceVoyage).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgenceVoyageExists(id))
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

        // POST: api/AgenceVoyages
        [ResponseType(typeof(AgenceVoyage))]
        public IHttpActionResult PostAgenceVoyage(AgenceVoyage agenceVoyage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AgenceVoyages.Add(agenceVoyage);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = agenceVoyage.IdAgenceVoyage }, agenceVoyage);
        }

        // DELETE: api/AgenceVoyages/5
        [Route("{IdAgenceVoyage}")]
        [ResponseType(typeof(AgenceVoyage))]
        public IHttpActionResult DeleteAgenceVoyage(int IdAgenceVoyage)
        {
            AgenceVoyage agenceVoyage = db.AgenceVoyages.Find(IdAgenceVoyage);
            if (agenceVoyage == null)
            {
                return NotFound();
            }

            db.AgenceVoyages.Remove(agenceVoyage);
            db.SaveChanges();

            return Ok(agenceVoyage);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AgenceVoyageExists(int id)
        {
            return db.AgenceVoyages.Count(e => e.IdAgenceVoyage == id) > 0;
        }
    }
}