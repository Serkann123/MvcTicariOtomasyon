using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Personel
    {
        [Key]
        public int Personelİd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersonelAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string personelSoyad { get; set; }

        [Column(TypeName = "Varchar")]
        public string personelGorsel { get; set; }

        public ICollection<SatisHareket> SatisHarekets { get; set; }

        public int departmanİd { get; set; }
        public  virtual Departman Departman { get; set; }
    }
}