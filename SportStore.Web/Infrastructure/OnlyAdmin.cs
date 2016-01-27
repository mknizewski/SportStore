using SportStore.Domain.Entities;
using SportStore.Web.HtmlHelpers.Classes;
using SportStore.Web.Models.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportStore.Web.Infrastructure
{
    public class OnlyAdmin : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var session = filterContext.HttpContext.Session["Employee"] as employees;
            var rule = session.Id_Rule;

            if (rule != (int)Rules.Admin)
            {
                filterContext.Result = new RedirectResult("/Pracownik/Konto");
                filterContext.Controller.TempData["Alert"] = EmployeeAlert.SetAlert(EmployyeAlerts.Danger, "Nie masz uprawnień do tego typu operacji!");
            }
        }
    }
}