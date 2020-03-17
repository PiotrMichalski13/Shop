﻿namespace FirstShop.Models
{
    public class PozycjaZamowienia
    {
        public int PozycjaZamowieiaId { get; set; }
        public int ZamowienieId { get; set; }
        public int KursId { get; set; }
        public int Ilosc { get; set; }
        public decimal CenaZakupu { get; set; }

        public virtual Kurs kurs { get; set; }
        public virtual Zamowienie zamowienie { get; set; }


    }
}