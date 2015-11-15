using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SportStore.Web
{
    /// <summary>
    /// Opis:   PRO TIP! Najpierw opisujemy szczegółowe trasy potem ogólne! Inaczej działać nie będzie!
    /// </summary>
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            #region Sklep
            routes.MapRoute("", "Sklep/Klient/Logowanie", new { controller = "Client", action = "Login" });
            routes.MapRoute("", "Sklep/Klient/Wylogowanie", new { controller = "Client", action = "Logout" });
            routes.MapRoute("", "Sklep/Klient/Rejestracja", new { controller = "Client", action = "Register" });
            routes.MapRoute("", "Sklep/Klient/{user}", new { controller = "Client", action = "AccountManagment", user = (string)null });
            routes.MapRoute("", "Sklep/Katalog/{catalogId}", new { controller = "Catalog", action = "Catalogs", catalogId = UrlParameter.Optional });

            routes.MapRoute("", "Sklep/Rejestracja", new { controller = "Home", action = "Register" });
            routes.MapRoute("", "Sklep/Newsletter", new { controller = "Home", action = "SaveNewsletter" });
            routes.MapRoute("", "Sklep/Wyszukiwarka", new { controller = "Search", action = "GlobalSearch" });
            routes.MapRoute("", "Sklep/Katalog", new { controller = "Catalog", action = "CatalogPartialView" });

            routes.MapRoute(
              name: "Default",
              url: "Sklep",
              defaults: new { controller = "Home", action = "Index", catalogId = UrlParameter.Optional }
          );
            #endregion


        }
    }
}
