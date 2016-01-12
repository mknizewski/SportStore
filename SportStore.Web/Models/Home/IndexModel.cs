using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportStore.Web.Models.Home
{
    public class IndexModel
    {
        public IEnumerable<TopRatedItemModel> TopRated { get; set; }
        public IEnumerable<LastAddedItemModel> LastAdded { get; set; }
    }
}