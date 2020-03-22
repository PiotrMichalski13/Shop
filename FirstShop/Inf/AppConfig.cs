using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace FirstShop.Inf
{
    public class AppConfig
    {
        private static string _ikonyKategoriiFolderWzgledny = ConfigurationManager.AppSettings["IkonyKAtegoriiFolder"];

        public static string IkonyKategoriiFolderWzgledny
        {
            get
            {
                return _ikonyKategoriiFolderWzgledny;
            }
            
        }
        private static string _ObrazkiFolderWzgledny = ConfigurationManager.AppSettings["ObrazkiFolder"];

        public static string ObrazkiFolderWzgledny
        {
            get
            {
                return _ObrazkiFolderWzgledny;
            }

        }

    }
}