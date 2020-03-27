using FirstShop.DAL;
using FirstShop.Inf;
using FirstShop.Models;
using FirstShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstShop.Controllers
{
    public class HomeController : Controller
    {
        private KursyContext db = new KursyContext();
  
        public ActionResult Index()
        { 
            
            ICacheProvider cache = new DefaultCacheProvider();

            List<Kategoria> kategorie;
            if (cache.IsSet(Const.KategorierCacheKey))
            {
                kategorie = cache.Get(Const.KategorierCacheKey) as List<Kategoria>;
            }
            else
            {
                kategorie = db.Kategorie.ToList();
                cache.Set(Const.KategorierCacheKey, kategorie, 60);
            }



            List<Kurs> nowosci;
            if (cache.IsSet(Const.NowosciCacheKey))
            {
                nowosci = cache.Get(Const.NowosciCacheKey) as List<Kurs>;
            }
            else
            {
                nowosci = db.Kursy.Where(a => !a.Ukryty).OrderByDescending(a => a.DataDodania).Take(3).ToList();
                cache.Set(Const.NowosciCacheKey, nowosci, 1);
            }

            List<Kurs> bestseller;
            if (cache.IsSet(Const.BestsellerCacheKey))
            {
                 bestseller = cache.Get(Const.BestsellerCacheKey) as List<Kurs>;
            }
            else
            {
                 bestseller = db.Kursy.Where(a => !a.Ukryty && a.Bestseller).OrderBy(a => Guid.NewGuid()).Take(3).ToList();
                cache.Set(Const.BestsellerCacheKey, bestseller, 1);
            }
            var vm = new HomeViewModel()
            {
                Kategorie = kategorie,
                Nowosci = nowosci,
                Bestsellery = bestseller

            };

            return View(vm);
        }

        public ActionResult StronyStatyczne(string nazwa)
        {
            return View(nazwa);
        }
        
    }
}