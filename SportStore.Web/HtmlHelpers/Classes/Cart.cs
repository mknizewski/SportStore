using SportStore.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SportStore.Web.HtmlHelpers.Classes
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(items item, int quantity)
        {
            CartLine line = lineCollection
                .Where(p => p.Item.Id.Equals(item.Id))
                .FirstOrDefault();

            if (line == null)
                lineCollection.Add(new CartLine() { Item = item, Quantity = quantity });
            else
                line.Quantity += quantity;
        }

        public void EditQuantity(int productId, int newQuantity)
        {
            lineCollection
                .Where(x => x.Item.Id.Equals(productId))
                .FirstOrDefault()
                .Quantity = newQuantity;
        }

        public void RemoveItem(items item)
        {
            lineCollection.RemoveAll(l => l.Item.Id.Equals(item.Id));
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(x => x.Item.Price * x.Quantity);
        }

        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }
    }
}