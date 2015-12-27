using SportStore.Web.HtmlHelpers.Classes;
using SportStore.Web.HtmlHelpers.Interfaces;
using SportStore.Web.Models.Catalog;
using SportStore.Web.Models.Home;
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
        private ICatalogRepository _catalogsHelper;

        public CatalogController(ICatalogRepository catalogHelper)
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

        public ActionResult AddToCart(Cart cart, int productId, int quantity)
        {
            var itemQuantity = _catalogsHelper.GetQuantityItemById(productId);

            if (itemQuantity != 0)
            {
                var item = _catalogsHelper.GetItemById(productId);
                cart.AddItem(item, quantity);

                Alert.SetAlert(AlertStatus.Succes, "Poprawnie dodano przedmiot do koszyka!");

                return RedirectToAction("ItemDescription", new { productId = productId });
            }
            else
            {
                Alert.SetAlert(AlertStatus.Danger, "Brak dostępnego towaru w sklepie!");
                return RedirectToAction("ItemDescription", new { productId = productId });
            }
        }

        public ActionResult RemoveItem(Cart cart, string returnUrl, int productId)
        {
            var item = _catalogsHelper.GetItemById(productId);
            cart.RemoveItem(item);

            Alert.SetAlert(AlertStatus.Info, "Porawnie usnięto produkt: " + item.Title);

            return Redirect(returnUrl);
        }

        public ActionResult EditQuantityItem(Cart cart, int productId, int newQuantity)
        {
            cart.EditQuantity(productId, newQuantity);

            Alert.SetAlert(AlertStatus.Info, "Poprawnie wprowadzono zmiany");

            return RedirectToAction("Cart", "Home");
        }

        [HttpPost]
        public FileContentResult GetImageByByte(byte[] array, string mimeType)
        {
            return File(array, mimeType);
        }

        public FileContentResult GetImage(int productId)
        {
            var content = _catalogsHelper.GetPictureById(productId);

            if (content != null)
                return File(content.PictureData, content.PictureMimeType);
            else
                return File(NonPictureHelper.NoImageArray, "image/png");
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