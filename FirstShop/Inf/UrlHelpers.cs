using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstShop.Inf
{
    public static class UrlHelpers
    {
        public static string KategorieIkonySciezka(this UrlHelper helper, string nazwaIkonyKategorii)
        {
            var IkonyKategoriiFolder = AppConfig.IkonyKategoriiFolderWzgledny;
            var sciezka = Path.Combine(IkonyKategoriiFolder, nazwaIkonyKategorii);
            var sciezkaBezwzgledna = helper.Content(sciezka);
            return sciezkaBezwzgledna;
        }

        public static string ObrazkiSciezka(this UrlHelper helper, string nazwaObrazka)
        {
            var ObrazkiFolder = AppConfig.ObrazkiFolderWzgledny;
            var sciezka = Path.Combine(ObrazkiFolder, nazwaObrazka);
            var sciezkaBezwzgledna = helper.Content(sciezka);
            return sciezkaBezwzgledna;
        }
    }
}