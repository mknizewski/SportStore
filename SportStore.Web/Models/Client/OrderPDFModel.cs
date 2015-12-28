using SportStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportStore.Web.Models.Client
{
    public class OrderPDFModel
    {
        public orders Order { get; set; }
        public IEnumerable<order_details> OrderDetails { get; set; }
    }
}