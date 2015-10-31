using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using SportStore.Domain.Concrete;
using System.Data.Entity;

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
