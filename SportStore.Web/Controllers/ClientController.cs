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
        private IAccountManagmentHelper _accountManagmentHelper { get; set; }

        public ClientController(IRegisterHelper registerHelper, ILoginHelper loginHelper, IAccountManagmentHelper accountManagmentHelper)
        {
            _registerHelper = registerHelper;
            _loginHelper = loginHelper;
            _accountManagmentHelper = accountManagmentHelper;
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

                var Client = _loginHelper.GetClient(loginModel.Login);
                this.Session["Client"] = Client;

                if (Client.UnreadNotifications != 0)
                    Alert.SetAlert(AlertStatus.Info, "Masz " + Client.UnreadNotifications + " nowe powiadomienia!");

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
        public ActionResult AccountManagment()
        {
            var cookie = this.Session["Client"] as AccountModel;
      
            return View(cookie);
        }

        [Authorize]
        [ClientAuthentication]
        public ActionResult Notyfications()
        {
            var id = (Session["Client"] as AccountModel).Id;

            return View(_accountManagmentHelper.GetNotifications(id));
        }

        [Authorize]
        [ClientAuthentication]
        public ActionResult MarkAsRead(List<MarkAsReadModel> markAsReadIds)
        {
            _accountManagmentHelper.MarkAsRead(markAsReadIds);

            return RedirectToAction("Notyfications");
        }

        public ActionResult Logout(string returnUrl)
        {
            this.Session["Client"] = null;
            FormsAuthentication.SignOut();

            return Redirect(returnUrl);
        }
    }
}