using SportStore.Domain.Entities;
using SportStore.Web.Models.Catalog;
using SportStore.Web.Models.Home;
using System.Collections.Generic;

namespace SportStore.Web.HtmlHelpers.Interfaces
{
    /// <summary>
    /// Autor:  Mateusz Kniżewski
    /// Opis:   Interfejs pomocy dla repo katalogów
    /// Data:   15.11.15
    /// </summary>
    public interface ICatalogHelper
    {
        IEnumerable<_dict_catalogs> GetCatalogs();

        IndexModel GetIndexModel();

        ProductsListViewModel GetItemsByCatalog(int catalogId, int page);

        items_picutures GetPictureById(int productId);

        ItemModel GetDescriptionItemById(int productId);

        void ChangePageSize(int newSize);

        void AddOpinion(OpinionModel opinionModel);

        items GetItemById(int productId);

        int GetQuantityItemById(int productId);

        void Dispose();
    }
}