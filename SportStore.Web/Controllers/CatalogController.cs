using SportStore.Web.HtmlHelpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Resources;
using System.IO;
using System.Drawing.Imaging;
using SportStore.Web.HtmlHelpers.Classes;

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

        public FileContentResult GetImage(int productId)
        {
            var content = _catalogsHelper.GetPictureById(productId);

            if (content != null)
                return File(content.PictureData, content.PictureMimeType);
            else
                return null;
        }
    }
}