using SportStore.Domain.Abstract;
using SportStore.Web.HtmlHelpers.Interfaces;
using SportStore.Web.Models.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SportStore.Web.HtmlHelpers.Classes
{
    public class GlobalSearchHelper : IGlobalSearchHelper
    {
        private ICatalogsRepository _catalogRepository;

        public GlobalSearchHelper(ICatalogsRepository catalogRepository)
        {
            _catalogRepository = catalogRepository;
        }

        GlobalSearchModel IGlobalSearchHelper.GetModel(string text)
        {
            var model = new GlobalSearchModel();

            //inicjacja DDL słowa
            var typeSearch = new List<SelectListItem>();
            typeSearch.Add(new SelectListItem { Text = "Zawiera", Value = "1" });
            typeSearch.Add(new SelectListItem { Text = "Zaczyna się", Value = "2" });
            typeSearch.Add(new SelectListItem { Text = "Nie zawiera", Value = "3" });
            typeSearch.Add(new SelectListItem { Text = "Kończy się", Value = "4" });
            model.TypeSearchWord = typeSearch;

            //inicjacja DDL filtru
            var filter = new List<SelectListItem>();
            filter.Add(new SelectListItem { Text = "Alfabetycznie", Value = "1" });
            filter.Add(new SelectListItem { Text = "Cena w dół", Value = "2" });
            filter.Add(new SelectListItem { Text = "Cena w górę", Value = "3" });
            model.Filter = filter;

            //inicjacja DDL kategori
            var catalog = new List<SelectListItem>();
            catalog.Add(new SelectListItem { Text = "Wszystkie", Value = "1" });
            var catalogs = _catalogRepository.Catalogs;

            foreach (var x in catalogs)
            {
                catalog.Add(
                        new SelectListItem { Text = x.Name, Value = (x.Id + 1).ToString() }
                    );
            }
            model.Category = catalog;

            if (!String.IsNullOrEmpty(text))
            {
                var selectedItems = _catalogRepository.Items
                .Where(x => x.Title.ToLower().Contains(text.ToLower()))
                .ToArray();

                model.searchedItems = selectedItems;
            }

            return model;
        }

        GlobalSearchModel IGlobalSearchHelper.SearchItems(GlobalSearchModel model)
        {
            //zczytujemy dane
            var word = model.Word;
            var selectedWord = model.SelectedTypeSearchWord;
            var selectedCategory = model.SelectedCategory;
            var selectedFilter = model.SelectedFilter;
            var odPrice = model.OdPirce;
            var doPrice = model.DoPrice;

            //inicjacja DDL słowa
            var typeSearch = new List<SelectListItem>();
            typeSearch.Add(new SelectListItem { Text = "Zawiera", Value = "1" });
            typeSearch.Add(new SelectListItem { Text = "Zaczyna się", Value = "2" });
            typeSearch.Add(new SelectListItem { Text = "Nie zawiera", Value = "3" });
            typeSearch.Add(new SelectListItem { Text = "Kończy się", Value = "4" });
            model.TypeSearchWord = typeSearch;

            //inicjacja DDL filtru
            var filter = new List<SelectListItem>();
            filter.Add(new SelectListItem { Text = "Alfabetycznie", Value = "1" });
            filter.Add(new SelectListItem { Text = "Cena w dół", Value = "2" });
            filter.Add(new SelectListItem { Text = "Cena w górę", Value = "3" });
            model.Filter = filter;

            //inicjacja DDL kategori
            var catalog = new List<SelectListItem>();
            catalog.Add(new SelectListItem { Text = "Wszystkie", Value = "1" });
            var catalogs = _catalogRepository.Catalogs;

            foreach (var x in catalogs)
            {
                catalog.Add(
                        new SelectListItem { Text = x.Name, Value = (x.Id + 1).ToString() }
                    );
            }
            model.Category = catalog;

            //pobieramy wszystkie itemki z bazy
            var items = _catalogRepository.Items.ToArray();

            //Sprawdzamy kategorię -- jeżeli nie wszystkie do wyciągamy tą konkretną
            if (selectedCategory != 1)
            {
                items = items
                        .Select(x => x)
                        .Where(x => x.Id_Category.Equals((selectedCategory - 1)))
                        .ToArray();
            }

            //Sprawdzamy słowo -- dostępne są 4 różne scieżki
            if (!String.IsNullOrEmpty(word))
            {
                switch (selectedWord)
                {
                    case 1:
                        items = items
                            .Where(x => x.Title.ToLower().Contains(word.ToLower()))
                            .ToArray();
                        break;

                    case 2:
                        items = items
                            .Where(x => x.Title.StartsWith(word))
                            .ToArray();
                        break;

                    case 3:
                        items = items
                            .Where(x => !(x.Title.ToLower().Contains(word.ToLower())))
                            .ToArray();
                        break;

                    case 4:
                        items = items
                            .Where(x => x.Title.EndsWith(word))
                            .ToArray();
                        break;
                }
            }

            //Sprawdzamy cenę -- 4 scieżki
            if (odPrice.HasValue && doPrice.HasValue)
            {
                items = items
                    .Where(x => (x.Price >= odPrice.Value || x.Price <= doPrice.Value))
                    .ToArray();
            }
            else if (odPrice.HasValue)
            {
                items = items
                    .Where(x => x.Price >= odPrice.Value)
                    .ToArray();
            }
            else if (doPrice.HasValue)
            {
                items = items
                    .Where(x => x.Price <= doPrice.Value)
                    .ToArray();
            }

            //filtracja wyników -- 3 sciezki
            switch (selectedFilter)
            {
                case 1:
                    items = items
                        .OrderBy(x => x.Title)
                        .ToArray();
                    break;

                case 2:
                    items = items
                        .OrderByDescending(x => x.Price)
                        .ToArray();
                    break;

                case 3:
                    items = items
                        .OrderBy(x => x.Price)
                        .ToArray();
                    break;
            }

            //zastąpienie itemków
            model.searchedItems = items;

            return model;
        }
    }
}