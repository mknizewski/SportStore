using Rotativa;
using SportStore.Web.HtmlHelpers.Classes;
using SportStore.Web.HtmlHelpers.Interfaces;
using SportStore.Web.Infrastructure;
using SportStore.Web.Infrastructure.Binders;
using SportStore.Web.Models.Client;
using SportStore.Web.Models.Home;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security;

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
        private IOrderHelper _orderHelper { get; set; }

        public ClientController(
            IRegisterHelper registerHelper,
            ILoginHelper loginHelper,
            IAccountManagmentHelper accountManagmentHelper,
            IOrderHelper orderHelper)
        {
            _registerHelper = registerHelper;
            _loginHelper = loginHelper;
            _accountManagmentHelper = accountManagmentHelper;
            _orderHelper = orderHelper;
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
        [HttpPost]
        public ActionResult EditDeliveryData(AccountModel model)
        {
            _accountManagmentHelper.ChangeDeliveryData(model);
            var Client = _loginHelper.GetClient(model.Login);
            this.Session["Client"] = Client;

            Alert.SetAlert(AlertStatus.Info, "Wprowadzono zmiany");

            return RedirectToAction("AccountManagment");
        }

        [Authorize]
        [ClientAuthentication]
        [HttpPost]
        public ActionResult ChangeClientPassword(int Id, string oldPassword, string newPassword)
        {
            if (_accountManagmentHelper.ChangePassword(Id, oldPassword, newPassword))
                Alert.SetAlert(AlertStatus.Succes, "Poprawnie zmieniono hasło dostępu!");
            else
                Alert.SetAlert(AlertStatus.Danger, "Podane stare hasło nie jest poprawne!");

            return RedirectToAction("AccountManagment");
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

        [Authorize]
        [ClientAuthentication]
        public ActionResult ArchivizeNote(List<int> ids)
        {
            _accountManagmentHelper.ArchivizeNote(ids);

            return RedirectToAction("Notyfications");
        }

        public ActionResult Logout(string returnUrl)
        {
            this.Session["Client"] = null;
            FormsAuthentication.SignOut();

            return Redirect(returnUrl);
        }

        [Authorize]
        [ClientAuthentication]
        [HttpGet]
        public ActionResult OrderDetails(Cart cart)
        {
            var client = Session["Client"] as AccountModel;

            Alert.SetAlert(AlertStatus.Warning, "Przy każdej zmianie opcji dostawy należy kliknąć w przycisk Przelicz!");
            return View(_orderHelper.GetOrderModel(cart, client));
        }

        [Authorize]
        [ClientAuthentication]
        [HttpPost]
        [MultipleButton(Name = "action", Argument = "RecalOrder")]
        public ActionResult RecalOrder(OrderModel model)
        {
            model = _orderHelper.RecalculateOrder(model);

            Alert.SetAlert(AlertStatus.Succes, "Poprawnie przeliczono!");
            return View("OrderDetails", model);
        }

        [Authorize]
        [ClientAuthentication]
        [HttpPost]
        [MultipleButton(Name = "action", Argument = "SaveOrder")]
        public ActionResult SaveOrder(OrderModel model)
        {
            if (ModelState.IsValid)
            {
                _orderHelper.AddOrder(model);

                var cart = Session["Cart"] as Cart;
                cart.Clear();

                Alert.SetAlert(AlertStatus.Succes, "Poprawnie złożono zamówienie! Status zamówienia można sprawdzić w sekcji Zamówienia");
                return RedirectToAction("AccountManagment");
            }
            else
                return View(model);
        }

        [Authorize]
        [ClientAuthentication]
        public ActionResult OrdersList()
        {
            var id = (Session["Client"] as AccountModel).Id;

            return View(_orderHelper.GetOrdersByClientId(id));
        }

        [Authorize]
        [ClientAuthentication]
        public ActionResult OrderDess(int orderId)
        {
            return View(_orderHelper.GetPDF(orderId));
        }

        [Authorize]
        [ClientAuthentication]
        [HttpGet]
        public ActionResult Invoice(int orderId)
        {
            return View(_orderHelper.GetPDF(orderId));
        }

        [Authorize]
        [ClientAuthentication]
        public ActionResult PDF(int orderID)
        {
            return new ActionAsPdf("Invoice", new { orderId = orderID })
            {
                PageSize = Rotativa.Options.Size.A4,
                FileName = "FV-SS-" + orderID + ".pdf"
            };
        }
    }
}