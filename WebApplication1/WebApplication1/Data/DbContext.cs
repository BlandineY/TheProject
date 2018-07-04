using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TodoList.Models;

namespace TodoList.Data
{
    public class DbContext : DbContext
    {
        public DbContext() : base("AJOUTER NOM BASE DE DONNEES") // Constructeur de la classe de base
        {
        }
    }
}