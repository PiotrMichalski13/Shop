﻿using FirstShop.Migrations;
using FirstShop.Models;
using System;
using System.Collections.Generic;

using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace FirstShop.DAL
{
    public class KursyInitializer : MigrateDatabaseToLatestVersion<KursyContext, Configuration>
    {
     
         
        public static void SeedKursyData(KursyContext context)
        {
            var kategorie = new List<Kategoria>
            {
                new Kategoria() {KategoriaId = 1, NazwaKategorii = "asp", NazwaPlikuIkony = "aspnet.png", OpisKategorii="Opis asp net mvc "},
                new Kategoria() {KategoriaId = 2, NazwaKategorii = "java", NazwaPlikuIkony = "java.png", OpisKategorii="Opisjava "},
                new Kategoria() {KategoriaId = 3, NazwaKategorii = "php", NazwaPlikuIkony = "php.png", OpisKategorii="Opis php "},
                new Kategoria() {KategoriaId = 4, NazwaKategorii = "python", NazwaPlikuIkony = "python.png", OpisKategorii="Opis python"},
                new Kategoria() {KategoriaId = 5, NazwaKategorii = "html", NazwaPlikuIkony = "html.png", OpisKategorii="Opis html "},
                new Kategoria() {KategoriaId = 6, NazwaKategorii = "c#", NazwaPlikuIkony = "css.png", OpisKategorii="Opis siszarp "},

            };
            kategorie.ForEach(k=>context.Kategorie.AddOrUpdate(k));
            context.SaveChanges();
            var kursy = new List<Kurs>
            {
                new Kurs() {KursId=1, AutorKursu="Piotrek", TytulKursu="Robienie ludzi w balonik vol. 1", KategoriaId=1, CenaKursu=99, Bestseller=false, NazwaPlikuObrazka="obrazekcss.png",
                 DataDodania=DateTime.Today,OpisKursu="Jak zrobić w balonik kogoś kto o to prosi"},
                 new Kurs() {KursId=2,AutorKursu="Wiesiek", TytulKursu="Robienie ludzi w balonik vol. 2", KategoriaId=1, CenaKursu=99, Bestseller=true, NazwaPlikuObrazka="kursbalonik.png",
                DataDodania=DateTime.Now, OpisKursu="Jak zrobić w balonik kogoś kto o to prosi"},
                  new Kurs() {KursId=3, AutorKursu="Roman", TytulKursu="Robienie ludzi w balonik vol. 3", KategoriaId=3, CenaKursu=99, Bestseller=true, NazwaPlikuObrazka="kursbalonik.png",
                DataDodania=DateTime.Now, OpisKursu="Jak zrobić w balonik kogoś kto o to prosi"},
                   new Kurs() {KursId=4,AutorKursu="Piotrek", TytulKursu="Robienie ludzi w balonik vol. 4", KategoriaId=1, CenaKursu=99, Bestseller=true, NazwaPlikuObrazka="kursbalonik.png",
                DataDodania=DateTime.Now, OpisKursu="Jak zrobić w balonik kogoś kto o to prosi", OpisSkrocony="Jebać stare baby"}
            };
            kursy.ForEach(k => context.Kursy.AddOrUpdate(k));
            context.SaveChanges();
            

        }
    }
}