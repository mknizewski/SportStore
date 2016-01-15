using SportStore.Domain.Entities;
using System.Collections.Generic;

namespace SportStore.Web.Models.Home
{
    public class TopRatedItemModel
    {
        public items Item { get; set; }
        public items_picutures Picure { get; set; }
        public IEnumerable<items_opinions> Opinions { get; set; }
    }
}