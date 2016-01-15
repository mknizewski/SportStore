using SportStore.Domain.Entities;
using System.Collections.Generic;

namespace SportStore.Web.Models.Client
{
    public class OrderPDFModel
    {
        public orders Order { get; set; }
        public IEnumerable<order_details> OrderDetails { get; set; }
    }
}