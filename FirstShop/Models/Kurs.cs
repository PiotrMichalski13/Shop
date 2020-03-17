using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstShop.Models
{
    public class Kurs
    {
        public int KursId { get; set; }
        public int KategoriaId{ get; set; }
        public string TytulKursu { get; set; }
        public string AutorKursu { get; set; }
        public DateTime DataDodania { get; set; }
        public string NazwaPlikuObrazka { get; set; }
        public string OpisKursu { get; set; }
        public decimal CenaKursu{ get; set; }
        public bool Bestseller { get; set; }
        public bool Ukryty { get; set; }

        public virtual Kategoria Kategoria { get; set; }
    }
}