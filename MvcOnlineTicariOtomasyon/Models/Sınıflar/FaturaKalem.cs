﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class FaturaKalem
    {
        [Key]
        public int FaturaKalemİd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Acıklama { get; set; }
        public int Miktar { get; set; }
        public decimal BirimFiyat { get; set; }
        public decimal Tutar { get; set; }

        public int Faturaİd { get; set; }
        public virtual Faturalar Faturalar { get; set; }
    }
}