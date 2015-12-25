using SportStore.Web.HtmlHelpers.Interfaces;
using SportStore.Web.Models.Search;
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
        private IGlobalSearchHelper _globalSearchHelper;
        public SearchController(IGlobalSearchHelper globalSearchHelper)
        {
            _globalSearchHelper = globalSearchHelper;
        }

        /// <summary>
        /// Wyszukiwanie globalne przedmiotu
        /// </summary>
        /// <param name="searchText">Szuakny przedmiot</param>
        /// <returns>Widok strony głownej wyszukiwania</returns>
        [HttpGet]
        public ActionResult GlobalSearch(string searchText)
        {
            return View(_globalSearchHelper.GetModel(searchText));
        }

        [HttpPost]
        public ActionResult GlobalSearch(GlobalSearchModel model)
        {
            return View(_globalSearchHelper.SearchItems(model));
        }
    }
}