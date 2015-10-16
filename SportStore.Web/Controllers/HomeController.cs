using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportStore.Web.Models.Home;

namespace SportStore.Web.Controllers
{
    /// <summary>
    /// Autor:  Mateusz Kniżewski
    /// Opis:   Klasa kontrolera głownej strony
    /// Data:   16.10.15
    /// </summary>
    public class HomeController : Controller
    {
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
            return View();
        }

        /// <summary>
        /// Metoda zapisująca model newsletter
        /// </summary>
        /// <param name="newsletter">obiekt typu newsletter</param>
        /// <returns>Widok NewsletterThanks</returns>
        [HttpPost]
        public ViewResult SaveNewsletter(Newsletter newsletter)
        {
            return View("NewsletterThanks", newsletter);
        }

        #endregion
    }
}