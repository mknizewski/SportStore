using SportStore.Web.HtmlHelpers.Interfaces;
using SportStore.Web.Models.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SportStore.Web.Infrastructure;

namespace SportStore.Web.Controllers
{
    /// <summary>
    /// Autor:  Mateusz Kniżewski
    /// Opis:   Kontroler klienta w sklepie SportStore
    /// Data:   07.11.15
    /// </summary>
    public class ClientController : Controller
    {
        private IRegisterHelper _registerHelper { get; set; }
        private ILoginHelper _loginHelper { get; set; }

        public ClientController(IRegisterHelper registerHelper, ILoginHelper loginHelper)
        {
            _registerHelper = registerHelper;
            _loginHelper = loginHelper;
        }

        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel loginModel, string returnUrl)
        {
            if (_loginHelper.IfExists(loginModel))
            {
                FormsAuthentication.SetAuthCookie(loginModel.Login, false);

                this.Session["Client"] = loginModel;

                return Redirect(Url.Action("Index", "Home"));
            }
            else
            {
                ModelState.AddModelError("", "Nieprawidłowa nazwa użytkownika bądź hasło");
                return View();
            }
        }

        [HttpGet]
        public ViewResult Register()
        {
            return View(_registerHelper.GetRegisterModel());
        }

        [HttpPost]
        public ViewResult Register(RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                _registerHelper.Save(registerModel);
                return View("registerThanks");
            }
            else
                return View(_registerHelper.GetRegisterModel());
        }

        [Authorize]
        [ClientAuthentication]
        public ActionResult AccountManagment()
        {
            return View();
        }

        public ActionResult Logout(string returnUrl)
        {
            this.Session["Client"] = null;
            FormsAuthentication.SignOut();

            return Redirect(Url.Action("Index", "Home"));
        }
    }
}