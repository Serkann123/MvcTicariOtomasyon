using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class FaturaViewModel
    {
        public int Faturaİd { get; set; }
        public string FaturaSeriNo { get; set; }
        public string FaturaSıraNo { get; set; }
        public DateTime FaturaTarih { get; set; }
        public string VergiDairesi { get; set; }
        public string Saat { get; set; }
        public string TeslimEden { get; set; }
        public decimal Toplam { get; set; }
        public string TeslimAlan { get; set; }
        public List<FaturaKalem> Kalemler { get; set; }
    }
}