using SportStore.Web.Models.Home;
using System.Web.Mvc;

namespace SportStore.Web.Infrastructure
{
    public class RedirectClient : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var session = filterContext.HttpContext.Session["Client"];

            if (session != null)
            {
                filterContext.Result = new RedirectResult("/Sklep");
                Alert.SetAlert(AlertStatus.Danger, "Jako klient nie masz dostępu do strefy pracowników!");
            }
        }
    }
}