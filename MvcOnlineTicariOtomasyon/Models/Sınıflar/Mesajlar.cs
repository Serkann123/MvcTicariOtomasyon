using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Mesajlar
    {
        [Key]
        public int MesajId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Gönderici { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Alici { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Konu { get; set; }

        public string İçerik { get; set; }

        [Column(TypeName = "Date")]
        public DateTime Tarih { get; set; }
    }
}