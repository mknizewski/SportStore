using SportStore.Domain.Concrete;
using SportStore.Web.HtmlHelpers.Classes;
using SportStore.Web.HtmlHelpers.Interfaces;
using SportStore.Web.Models.Client;
using SportStore.Web.Models.Home;
using System.Web.Mvc;

namespace SportStore.Web.Controllers
{
    /// <summary>
    /// Autor:  Mateusz Kniżewski
    /// Opis:   Klasa kontrolera głownej strony sklepu
    /// Data:   16.10.15
    /// </summary>
    public class HomeController : Controller
    {
        private INewsletterHelper _newsletterHelper;

        public HomeController(INewsletterHelper newsletterHelper)
        {
            _newsletterHelper = newsletterHelper;
        }

        #region Metody Kontrolera

        /// <summary>
        /// Metoda defaultowa
        /// </summary>
        /// <returns>Widok Index</returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Metoda wyswietlajaca widok zapisu do newslettera
        /// </summary>
        /// <returns>Widok SaveNewsletter</returns>
        [HttpGet]
        public ViewResult SaveNewsletter()
        {
            return View(_newsletterHelper.GetNewsletterModel());
        }

        /// <summary>
        /// Metoda zapisująca model newsletter
        /// </summary>
        /// <param name="newsletter">obiekt typu newsletter</param>
        /// <returns>Widok NewsletterThanks</returns>
        [HttpPost]
        public ViewResult SaveNewsletter(NewsletterModel newsletter)
        {
            if (ModelState.IsValid)
            {
                if (_newsletterHelper.TrySave(newsletter))
                {
                    ViewBag.Email = newsletter.Email;
                    Alert.SetAlert(AlertStatus.Succes, "Poprawnie zapisano do newslettera!");
                    return View("Index");
                }
                else
                    return View(_newsletterHelper.GetNewsletterModel());
            }
            else
                return View(_newsletterHelper.GetNewsletterModel());
        }

        public ViewResult Cart(Cart cart)
        {
            return View(cart);
        }

        public ViewResult AboutUs()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            var model = new ContactModel();

            if (Session["Client"] != null)
            {
                model.Email = (Session["Client"] as AccountModel).Login;
                model.Id_Client = (Session["Client"] as AccountModel).Id;
            }

            ViewBag.Shops = new EFDbContext().DictShops;

            return View(model);
        }

        [HttpPost]
        public ActionResult Contact(ContactModel model)
        {
            if (ModelState.IsValid)
            {
                Alert.SetAlert(AlertStatus.Succes, "Dziękujemy za wiadomość! Postaramy się odpowiedzieć w jak najszybszym tempie!");
                return RedirectToAction("Index");
            }
            else
            {
                return Contact();
            }
        }

        #endregion Metody Kontrolera
    }
}