using SportStore.Domain.Entities;

namespace SportStore.Web.HtmlHelpers.Classes
{
    public class CartLine
    {
        public items Item { get; set; }
        public int Quantity { get; set; }
    }
}