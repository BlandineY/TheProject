using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TodoList.Models;

namespace TodoList.Data
{
    public class DbContextBoVoyage : DbContext
    {
        public DbContext() : base("AJOUTER NOM BASE DE DONNEES") // Constructeur de la classe de base
        {
        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Voyage> Voyages { get; set; }

    }
}