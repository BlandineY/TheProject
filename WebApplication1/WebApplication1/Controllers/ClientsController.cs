using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BoVoyage.Data;
using BoVoyage.Models;

namespace WebApplication1.Controllers
{
    public class ClientsController : ApiController
    {
        //Ouverture de la connexion à la Base de données
        [RoutePrefix("Api/clients")]

        public class CategoriesController : ApiController
        {
            //ouverture de la connexion à la db
            private BoVoyageDbContext db = new BoVoyageDbContext();

            //GET: api/clients
           /* public IQueryable<Client> GetClient()
            {
                return db.Clients.Where(x => !x.Deleted);
            }*/
        }

    }
}
