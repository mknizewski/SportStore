using Ninject;
using SportStore.Domain.Abstract;
using SportStore.Domain.Entities;
using SportStore.Web.HtmlHelpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportStore.Web.HtmlHelpers.Classes
{
    public class CatalogsHelper : ICatalogsHelper
    {
        public ICatalogsRepository _catalogRepository;

        public CatalogsHelper(ICatalogsRepository catalogRepository)
        { 
            _catalogRepository = catalogRepository;
        }

        private IEnumerable<SelectListItem> GetCatalogsList(IEnumerable<_dict_catalogs> list)
        {
            var newList = new List<SelectListItem>();

            foreach (var element in list)
                newList.Add(new SelectListItem()
                {
                    Value = element.Id.ToString(),
                    Text = element.Name
                });

            return newList;
        }

        IEnumerable<SelectListItem> ICatalogsHelper.GetCatalogs()
        {
            return GetCatalogsList(_catalogRepository.Catalogs);
        }
    }
}