﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Departman
    {
        [Key]
        public int Departmanİd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string DepartmanAd { get; set; }

        public bool DepartmanStatus { get; set; }
 
        public ICollection<Personel> Personels { get; set; }
    }
}