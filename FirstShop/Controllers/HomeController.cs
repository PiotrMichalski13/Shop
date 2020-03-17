using FirstShop.DAL;
using FirstShop.Models;
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
            Kategoria kategoria = new Kategoria { NazwaKategorii = "asp.net mvc", NazwaPlikuIkony = "aspNetMvc.png", OpisKategorii = "opis" };
               db.Kategorie.Add(kategoria);
            db.SaveChanges(); 
            return View();
        }
    }
}