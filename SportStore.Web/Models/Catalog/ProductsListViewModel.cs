using SportStore.Domain.Entities;
using SportStore.Web.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportStore.Web.Models.Catalog
{
    public class ProductsListViewModel
    {
        public IEnumerable<items> Items { get; set; }
        public PagingModel pagingModel { get; set; }
        public string CurrentCategory { get; set; }
        public int CurrentCategoryId { get; set; }
    }
}