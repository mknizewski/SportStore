using SportStore.Domain.Entities;
using System.Collections.Generic;

namespace SportStore.Web.Models.Home
{
    public class LastAddedItemModel
    {
        public items Item { get; set; }
        public items_picutures Picture { get; set; }
        public IEnumerable<items_opinions> Opinions { get; set; }
    }
}