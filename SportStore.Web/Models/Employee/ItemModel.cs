using SportStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportStore.Web.Models.Employee
{
    public class ItemModel
    {
        public items Item { get; set; }
        public int SelectedCategory { get; set; }
        public List<string> DetailsItem { get; set; }
        public List<items_picutures> Pictures { get; set; }
        public List<items_quantity> Quantity { get; set; }
    }
}