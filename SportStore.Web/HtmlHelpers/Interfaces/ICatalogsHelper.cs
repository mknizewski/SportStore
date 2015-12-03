using SportStore.Domain.Entities;
using SportStore.Web.Models.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SportStore.Web.HtmlHelpers.Interfaces
{
    /// <summary>
    /// Autor:  Mateusz Kniżewski
    /// Opis:   Interfejs pomocy dla repo katalogów
    /// Data:   15.11.15
    /// </summary>
    public interface ICatalogsHelper
    {
        IEnumerable<_dict_catalogs> GetCatalogs();
        ProductsListViewModel GetItemsByCatalog(int catalogId, int page);
        items_picutures GetPictureById(int productId);
        ItemModel GetDescriptionItemById(int productId);
        void ChangePageSize(int newSize);
        void AddOpinion(OpinionModel opinionModel);
    }
}
