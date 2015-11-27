using SportStore.Web.HtmlHelpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportStore.Web.Controllers
{
    /// <summary>
    /// Autor:  Mateusz Kniżewski
    /// Opis:   Kontroler katalogów produktów oraz przedmiotów
    /// Data:   15.11.15
    /// </summary>
    public class CatalogController : Controller
    {
        private ICatalogsHelper _catalogsHelper;

        public CatalogController(ICatalogsHelper catalogHelper)
        {
            _catalogsHelper = catalogHelper;
        }

        public PartialViewResult CatalogPartialView()
        {
            return PartialView(_catalogsHelper.GetCatalogs());
        }

        public ActionResult Catalogs(int catalogId, int page)
        {
            return View(_catalogsHelper.GetItemsByCatalog(catalogId, page));
        }

        public ViewResult ItemDescription()
        {
            return View();
        }
    }
}