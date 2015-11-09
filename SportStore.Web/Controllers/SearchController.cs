using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportStore.Web.Controllers
{
    /// <summary>
    /// Autor:  Mateusz Kniżewski
    /// Opis:   09.11.15
    /// Data:   Klasa kontrolera obsługującego wyszukiwanie danych w systemie SportStore
    /// </summary>
    public class SearchController : Controller
    {
        /// <summary>
        /// Wyszukiwanie globalne przedmiotu
        /// </summary>
        /// <param name="searchText">Szuakny przedmiot</param>
        /// <returns>Widok strony głownej wyszukiwania</returns>
        [HttpPost]
        public ActionResult GlobalSearch(string searchText)
        {
            return View();
        }
    }
}