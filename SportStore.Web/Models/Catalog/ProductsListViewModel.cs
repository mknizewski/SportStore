using SportStore.Domain.Entities;
using SportStore.Web.Models.Shared;
using System.Collections.Generic;

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