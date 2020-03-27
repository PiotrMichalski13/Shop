using FirstShop.DAL;
using FirstShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstShop.Inf
{
    public class KoszykManager
    {
        private KursyContext db;
        private ISessionManager session;
        public KoszykManager(ISessionManager session, KursyContext db)
        {
            this.session = session;
            this.db = db;

        }

        public List<PozycjaKoszyka> PobierzKoszyk()
        {
            List<PozycjaKoszyka> koszyk;
            if (session.Get<List<PozycjaKoszyka>>(Const.KoszykSessionKey) == null)
            {
                koszyk = new List<PozycjaKoszyka>();
            }
            else
            {
                koszyk = session.Get<List<PozycjaKoszyka>>(Const.KoszykSessionKey) as List<PozycjaKoszyka>;
            }

            return koszyk;
                }
        public void DodajDoKoszyka(int kursId)
        {
            var koszyk = PobierzKoszyk();
            var pozycjaKoszyka = koszyk.Find(k => k.Kurs.KursId == kursId);

            if (pozycjaKoszyka != null)
                pozycjaKoszyka.Ilosc++;
            else
            {
                var kursDoDodania = db.Kursy.Where(k => k.KursId == kursId).SingleOrDefault();

                if (kursDoDodania != null)
                {
                    var nowaPozycjaKoszyka = new PozycjaKoszyka()
                    {
                        Kurs = kursDoDodania,
                        Ilosc = 1,
                        Wartosc = kursDoDodania.CenaKursu
                    };
                    koszyk.Add(nowaPozycjaKoszyka);
                }
            }

            session.Set(Const.KoszykSessionKey, koszyk);
        }

        public int UsunZKoszyka(int kursId)
        {
            var koszyk = PobierzKoszyk();
            var pozycjaKoszyka = koszyk.Find(k => k.Kurs.KursId == kursId);

            if (pozycjaKoszyka != null)
            {
                if (pozycjaKoszyka.Ilosc > 1)
                {
                    pozycjaKoszyka.Ilosc--;
                    return pozycjaKoszyka.Ilosc;
                }
                else
                {
                    koszyk.Remove(pozycjaKoszyka);
                }
            }

            return 0;
        }

        public decimal PobierzWartoscKoszyka()
        {
            var koszyk = PobierzKoszyk();
            return koszyk.Sum(k => (k.Ilosc * k.Kurs.CenaKursu));
        }

        public int PobierzIloscPozycjiKoszyka()
        {
            var koszyk = PobierzKoszyk();
            int ilosc = koszyk.Sum(k => k.Ilosc);   
            return ilosc;
        }

        public Zamowienie UtworzZamowienie(Zamowienie noweZamowienie, string userId)
        {
            var koszyk = PobierzKoszyk();
            noweZamowienie.DataDodania = DateTime.Now;
            //noweZamowienie.UserId = userId;

            db.Zamowienia.Add(noweZamowienie);
            //jeśli nie działa to tutaj musi być inaczej w pozycji zamóienia
            if (noweZamowienie.PozycjaZamowienia == null)
                noweZamowienie.PozycjaZamowienia = new List<PozycjaZamowienia>();

            decimal koszykWartosc = 0;

            foreach (var koszykElement in koszyk)
            {
                var nowaPozycjaZamowienia = new PozycjaZamowienia()
                {
                    KursId = koszykElement.Kurs.KursId,
                    Ilosc = koszykElement.Ilosc,
                    CenaZakupu = koszykElement.Kurs.CenaKursu
                };

                koszykWartosc += (koszykElement.Ilosc * koszykElement.Kurs.CenaKursu);
                noweZamowienie.PozycjaZamowienia.Add(nowaPozycjaZamowienia);
            }

            noweZamowienie.WartoscZamowienia = koszykWartosc;
            db.SaveChanges();

            return noweZamowienie;
        }

        public void PustyKoszyk()
        {
            session.Set<List<PozycjaKoszyka>>(Const.KoszykSessionKey, null);
        }
    }
    
}