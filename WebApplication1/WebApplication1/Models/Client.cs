using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BoVoyage.Models;

namespace BoVoyage.Models
{
    public class Client : Personne
    {
        [Key]
        public int IdClients { get; set; }
        public string Email { get; set; }
    }
}


