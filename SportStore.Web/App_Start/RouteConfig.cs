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

            routes.MapRoute("", "Sklep/Klient/Logowanie", new { controller = "Client", action = "Login" });
            routes.MapRoute("", "Sklep/Klient/Wylogowanie", new { controller = "Client", action = "Logout" });
            routes.MapRoute("", "Sklep/Klient/Rejestracja", new { controller = "Client", action = "Register" });
            routes.MapRoute("", "Sklep/Klient/Zarzadzanie", new { controller = "Client", action = "AccountManagment" });
            routes.MapRoute("", "Sklep/Klient/Powiadomienia", new { controller = "Client", action = "Notyfications"});
            routes.MapRoute("", "Sklep/Klient/Powiadomienia/{id}", new { controller = "Client", action = "DeleteNote", id = UrlParameter.Optional });
            routes.MapRoute("", "Sklep/Katalog/{catalogId}/{page}", new { controller = "Catalog", action = "Catalogs", catalogId = UrlParameter.Optional, page = UrlParameter.Optional });
            routes.MapRoute("", "Sklep/Katalog/Dodaj/{catalogId}/{productId}", new { controller = "Catalog", action = "AddToCart", productId = UrlParameter.Optional, catalogId = UrlParameter.Optional });
            routes.MapRoute("", "Zdjecie/{productId}", new { controller = "Catalog", action = "GetImage", productId = UrlParameter.Optional });

            routes.MapRoute("", "Sklep/Rejestracja", new { controller = "Home", action = "Register" });
            routes.MapRoute("", "Sklep/Newsletter", new { controller = "Home", action = "SaveNewsletter" });
            routes.MapRoute("", "Sklep/Wyszukiwarka", new { controller = "Search", action = "GlobalSearch" });
            routes.MapRoute("", "Sklep/Katalog", new { controller = "Catalog", action = "CatalogPartialView" });

            routes.MapRoute("", "Pracownik/Logowanie", new { controller = "Employee", action = "Login" });

            routes.MapRoute(
              name: "",
              url: "",
              defaults: new { controller = "Home", action = "Index" }
          );

            routes.MapRoute(
              name: "Default",
              url: "Sklep",
              defaults: new { controller = "Home", action = "Index" }
          );

        }
    }
}
