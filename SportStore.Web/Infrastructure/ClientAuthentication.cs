using System.Security.Principal;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;

namespace SportStore.Web.Infrastructure
{
    /// <summary>
    /// Autor:  Mateusz Kniżewski
    /// Opis:   Klasa uwierzytelniająca klientów serwisu SportStore
    /// Data:   07.11.15
    /// </summary>
    public class ClientAuthentication : FilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            IIdentity ident = filterContext.Principal.Identity;

            if (!ident.IsAuthenticated)
                filterContext.Result = new HttpUnauthorizedResult();
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary {
                    {"controller", "Client"},
                    {"action", "Login"},
                    {"returnUrl", filterContext.HttpContext.Request.RawUrl}
                });
            }
        }
    }
}