﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BoVoyage.Models;

namespace BoVoyage.Models
{
    public class Assurance
    {
        [Key]
        public int IdAssurance { get; set; }
        public string Description { get; set; }
    }
}
