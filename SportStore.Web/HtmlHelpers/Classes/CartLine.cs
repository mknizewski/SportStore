using SportStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportStore.Web.HtmlHelpers.Classes
{
    public class CartLine
    {
        public items Item { get; set; }
        public int Quantity { get; set; }
    }
}