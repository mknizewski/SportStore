using SportStore.Domain.Concrete;
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
            //Inicjalizacja bazy danych
            Database.SetInitializer(new EFDbInitializer());
        }
    }
}