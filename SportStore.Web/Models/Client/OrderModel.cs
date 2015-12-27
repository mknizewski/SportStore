using SportStore.Web.HtmlHelpers.Classes;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SportStore.Web.Models.Client
{
    public class OrderModel
    {
        public Cart cart { get; set; }
        public AccountModel Client { get; set; }
        public int selectedDeliveryId { get; set; }
        public IEnumerable<SelectListItem> OrderDelivery { get; set; }
        public decimal TotalPrice { get; set; }
    }
}