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
            routes.MapRoute("", "Sklep/Klient/Zarzadzanie/ZmianaHasla", new { controller = "Client", action = "ChangeClientPassword" });
            routes.MapRoute("", "Sklep/Klient/Zarzadzanie/ZmianaWysylkowa", new { controller = "Client", action = "EditDeliveryData" });
            routes.MapRoute("", "Sklep/Klient/Zamowienia", new { controller = "Client", action = "OrdersList" });
            routes.MapRoute("", "Sklep/Klient/Zamowienia/{orderId}", new { controller = "Client", action = "OrderDess", orderId = UrlParameter.Optional });
            routes.MapRoute("", "Sklep/Klient/Powiadomienia", new { controller = "Client", action = "Notyfications" });
            routes.MapRoute("", "Sklep/Klient/Powiadomienia/Przeczytane", new { controller = "Client", action = "MarkAsRead" });
            routes.MapRoute("", "Sklep/Klient/Powiadomienia/Archiwizuj", new { controller = "Client", action = "ArchivizeNote" });
            routes.MapRoute("", "Sklep/Katalog/{catalogId}/{page}", new { controller = "Catalog", action = "Catalogs", catalogId = UrlParameter.Optional, page = UrlParameter.Optional });
            routes.MapRoute("", "Sklep/Katalog/{catalogId}/Produkt/{productId}", new { controller = "Catalog", action = "ItemDescription", productId = UrlParameter.Optional, catalogId = UrlParameter.Optional });
            routes.MapRoute("", "Sklep/Katalog/{catalogId}/Produkt/{productId}/Dodaj/{quantity}", new { controller = "Catalog", action = "AddToCart", productId = UrlParameter.Optional, catalogId = UrlParameter.Optional, quantity = UrlParameter.Optional });
            routes.MapRoute("", "Sklep/Koszyk/Edytuj/{productId}/{newQuantity}", new { controller = "Catalog", action = "EditQuantityItem", productId = UrlParameter.Optional, newQuantity = UrlParameter.Optional });
            routes.MapRoute("", "Sklep/Koszyk/Usun/{productId}", new { controller = "Catalog", action = "RemoveItem", productId = UrlParameter.Optional });
            routes.MapRoute("", "Zdjecie/{productId}", new { controller = "Catalog", action = "GetImage", productId = UrlParameter.Optional });
            routes.MapRoute("", "Sklep/Zamowienie/Przelicz", new { controller = "Client", action = "RecalOrder" });
            routes.MapRoute("", "Sklep/Zamowienie/Dodaj", new { controller = "Client", action = "SaveOrder" });
            routes.MapRoute("", "Sklep/Zamowienie/Generuj/{orderId}", new { controller = "Client", action = "PDF", orderId = UrlParameter.Optional });
            routes.MapRoute("", "Sklep/Zamowienie/Faktura/{orderId}", new { controller = "Client", action = "Invoice", orderId = UrlParameter.Optional });
            routes.MapRoute("", "Sklep/Zamowienie", new { controller = "Client", action = "OrderDetails" });
            routes.MapRoute("", "Sklep/Zdjecie/{array}/{mimeType}", new { controller = "Catalog", action = "GetImageByByte", array = UrlParameter.Optional, mimeType = UrlParameter.Optional });


            routes.MapRoute("", "Sklep/Rejestracja", new { controller = "Home", action = "Register" });
            routes.MapRoute("", "Sklep/Newsletter", new { controller = "Home", action = "SaveNewsletter" });
            routes.MapRoute("", "Sklep/Wyszukiwarka", new { controller = "Search", action = "GlobalSearch" });
            routes.MapRoute("", "Sklep/Katalog", new { controller = "Catalog", action = "CatalogPartialView" });
            routes.MapRoute("", "Sklep/Koszyk", new { controller = "Home", action = "Cart" });
            routes.MapRoute("", "Sklep/Onas", new { controller = "Home", action = "AboutUs" });
            routes.MapRoute("", "Sklep/Kontakt", new { controller = "Home", action = "Contact" });

            routes.MapRoute("", "Pracownik/Konto/Katalogi/Edycja", new { controller = "Employee", action = "CatalogEdit", id = UrlParameter.Optional, name = UrlParameter.Optional });
            routes.MapRoute("", "Pracownik/Konto/Katalogi/Usun", new { controller = "Employee", action = "CatalogDelete", id = UrlParameter.Optional });
            routes.MapRoute("", "Pracownik/Konto/Katalogi/Dodaj", new { controller = "Employee", action = "CatalogAdd", catalogName = UrlParameter.Optional });

            routes.MapRoute("", "Pracownik/Konto/Produkty/Opinie/Usun/{id}", new { controller = "Employee", action = "DeleteOpinion", id = UrlParameter.Optional });
            routes.MapRoute("", "Pracownik/Konto/Produkty/Opinie", new { controller = "Employee", action = "Opinions" });
            routes.MapRoute("", "Pracownik/Konto/Produkty", new { controller = "Employee", action = "ItemsManagment" });
            routes.MapRoute("", "Pracownik/Konto/Produkty/Dodaj", new { controller = "Employee", action = "ItemAdd" });
            routes.MapRoute("", "Pracownik/Konto/Produkty/{id}", new { controller = "Employee", action = "ItemsEdit", id = UrlParameter.Optional });

            routes.MapRoute("", "Pracownik/Logowanie", new { controller = "Employee", action = "Login" });
            routes.MapRoute("", "Pracownik/Konto/GenerujKey", new { controller = "Employee", action = "GenerateRegisterKey"});
            routes.MapRoute("", "Pracownik/Konto/Katalogi", new { controller = "Employee", action = "CatalogManagment" });
            routes.MapRoute("", "Pracownik/Konto/Wyloguj", new { controller = "Employee", action = "Logout" });
            routes.MapRoute("", "Pracownik/Rejestracja", new { controller = "Employee", action = "Register" });
            routes.MapRoute("", "Pracownik/Konto", new { controller = "Employee", action = "Index" });

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