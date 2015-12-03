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
using SportStore.Web.Models.Home;
using SportStore.Web.Models.Catalog;

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

        [HttpGet]
        public ActionResult ItemDescription(int productId)
        {
            return View(_catalogsHelper.GetDescriptionItemById(productId));
        }

        public ActionResult AddToCart(string returnUrl, int productId)
        {
            //TODO: Dodać obsługę koszyka!
            Alert.SetAlert(AlertStatus.Succes, "Poprawnie dodano przedmiot do koszyka!");

            return Redirect(returnUrl);
        }

        public FileContentResult GetImage(int productId)
        {
            var content = _catalogsHelper.GetPictureById(productId);

            if (content != null)
                return File(content.PictureData, content.PictureMimeType);
            else
                return null;
        }

        [HttpPost]
        [ActionName("ItemDescription")]
        public ActionResult AddOpinion(OpinionModel opinionModel)
        {
            Alert.SetAlert(AlertStatus.Succes, "Poprawnie dodano opinię. Dziękujemy!");
            _catalogsHelper.AddOpinion(opinionModel);

            return Json("");
        }
    }
}