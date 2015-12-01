using SportStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportStore.Web.Models.Catalog
{
    public class ItemModel
    {
        public items Item { get; set; }
        public IEnumerable<items_opinions> Opinions { get; set; }
        public IEnumerable<items_picutures> Pictures { get; set; }
        public IEnumerable<items_quantity> Quantity { get; set; }
    }
}