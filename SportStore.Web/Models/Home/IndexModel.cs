using System.Collections.Generic;

namespace SportStore.Web.Models.Home
{
    public class IndexModel
    {
        public IEnumerable<TopRatedItemModel> TopRated { get; set; }
        public IEnumerable<LastAddedItemModel> LastAdded { get; set; }
    }
}