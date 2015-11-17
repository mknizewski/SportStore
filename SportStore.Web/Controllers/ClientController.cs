using SportStore.Web.HtmlHelpers.Interfaces;
using SportStore.Web.Models.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SportStore.Web.Infrastructure;
using SportStore.Web.Models.Home;

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

                var split = loginModel.Login.Split(new char[] { '@' });

                this.Session["Client"] = split[0];

                Alert.SetAlert(AlertStatus.Info, "Witaj " + split[0]);

                if (returnUrl != null)
                    return Redirect(returnUrl);
                else
                    return RedirectToAction("Index", "Home", new { controller = "Home", action = "Index" });
            }
            else
            {
                ModelState.AddModelError("", "Nieprawidłowa nazwa użytkownika bądź hasło");
                return View();
            }
        }

        [HttpGet]
        public ActionResult Register(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(_registerHelper.GetRegisterModel());
        }

        [HttpPost]
        public ActionResult Register(RegisterModel registerModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                _registerHelper.Save(registerModel);
                Alert.SetAlert(AlertStatus.Succes, "Poprawnie założono konto klienta! Możesz teraz zalogować się do serwisu używając danych podanych w rejestracji.");
                return RedirectToAction("Login");
            }
            else
                return View(_registerHelper.GetRegisterModel());
        }

        [Authorize]
        [ClientAuthentication]
        public ActionResult AccountManagment(string user)
        {
            return View();
        }

        public ActionResult Logout(string returnUrl)
        {
            this.Session["Client"] = null;
            FormsAuthentication.SignOut();

            return Redirect(returnUrl);
        }
    }
}