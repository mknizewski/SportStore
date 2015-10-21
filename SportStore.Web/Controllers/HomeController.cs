using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportStore.Web.Models.Home;
using SportStore.Domain.Abstract;
using SportStore.Domain.Entities;
using SportStore.Web.HtmlHelpers.Interfaces;

namespace SportStore.Web.Controllers
{
    /// <summary>
    /// Autor:  Mateusz Kniżewski
    /// Opis:   Klasa kontrolera głownej strony
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
        public ActionResult SaveNewsletter(NewsletterModel newsletter)
        {
            //tymczasowe, później bd sprawdzać czy model jest właściwy
            _newsletterHelper.SaveToDb(newsletter);

            ViewBag.Email = newsletter.Email;

            return View("NewsletterThanks");
        }

        #endregion
    }
}