using SportStore.Domain.Concrete;
using SportStore.Web.HtmlHelpers.Classes;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Routing;

namespace SportStore.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            //Rejestracja tablicy routingu
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //Inicjalizacja braku zdjęcia
            NonPictureHelper.GetNoImage();
            //Inicjalizacja bazy danych
            Database.SetInitializer(new EFDbInitializer());
        }
    }
}