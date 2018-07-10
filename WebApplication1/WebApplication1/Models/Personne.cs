using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BoVoyage.Models;

namespace BoVoyage.Models
{
    public class Personne
    {
        public string Civilite { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adresse { get; set; }
        public string Telephone { get; set; }
        public System.DateTime DateNaissance { get; set; }
        [NotMapped]
        public int Age
        {
            get
            {
                return (DateTime.Today - DateNaissance).Days / 365;
            }
        }
    }
}