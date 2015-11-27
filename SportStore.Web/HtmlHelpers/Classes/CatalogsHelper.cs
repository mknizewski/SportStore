using Ninject;
using SportStore.Domain.Abstract;
using SportStore.Domain.Entities;
using SportStore.Web.HtmlHelpers.Interfaces;
using SportStore.Web.Models.Catalog;
using SportStore.Web.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportStore.Web.HtmlHelpers.Classes
{
    /// <summary>
    /// Autor:  Mateusz Kniżewski
    /// Opis:   Klasa pomocniczna do przegladania produktów
    /// Data:   26.11.15
    /// </summary>
    public class CatalogsHelper : ICatalogsHelper
    {
        public ICatalogsRepository _catalogRepository;
        private const int PageSize = 9; //ilosc itemow na stronie

        public CatalogsHelper(ICatalogsRepository catalogRepository)
        { 
            _catalogRepository = catalogRepository;
        }

        IEnumerable<_dict_catalogs> ICatalogsHelper.GetCatalogs()
        {
            return _catalogRepository.Catalogs;
        }

        Models.Catalog.ProductsListViewModel ICatalogsHelper.GetItemsByCatalog(int catalogId, int page)
        {
            var helperPage = page;
            if (page.Equals(1))
                helperPage = 0;

            var currentCatalog = _catalogRepository.Catalogs
                                .Select(x => x)
                                .Where(x => x.Id.Equals(catalogId))
                                .FirstOrDefault();

            var viewModel = new ProductsListViewModel
            {
                Items = _catalogRepository.Items
                        .Where(x => x.Id_Category.Equals(catalogId))
                        .OrderBy(x => x.Id)
                        .Skip(helperPage * PageSize)
                        .Take(PageSize),

                pagingModel = new PagingModel
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = _catalogRepository.Items
                                .Select(x => x)
                                .Where(x => x.Id_Category.Equals(catalogId))
                                .Count()
                },

                CurrentCategory = currentCatalog.Name,
                CurrentCategoryId = catalogId
            };

            return viewModel;
        }
    }
}