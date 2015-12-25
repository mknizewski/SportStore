using SportStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportStore.Web.Models.Search
{
    /// <summary>
    /// Autor:  Mateusz Kniżewski
    /// Opis:   Klasa modelowa globalnej wyszukiwarki
    /// Data:   25.12.15
    /// </summary>
    public class GlobalSearchModel
    {
        public string Word { get; set; }

        public IEnumerable<SelectListItem> TypeSearchWord { get; set; }
        public int SelectedTypeSearchWord { get; set; }

        public IEnumerable<SelectListItem> Filter { get; set; }
        public int SelectedFilter { get; set; }

        public IEnumerable<SelectListItem> Category { get; set; }
        public int SelectedCategory { get; set; }

        public IEnumerable<items> searchedItems { get; set; }

        public decimal? OdPirce { get; set; }
        public decimal? DoPrice { get; set; }
    }
}