using SportStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportStore.Domain.Abstract
{
    public interface IDictionaryRepository
    {
        IEnumerable<_dict_catalogs> DictCatalogs { get; set; }
        IEnumerable<_dict_cities> DictCities { get; set; }
        IEnumerable<_dict_description_items> DictDescriptionItems { get; set; }
        IEnumerable<_dict_items_details> DictItemsDetails { get; set; }
        IEnumerable<_dict_newsletter> DictNewsletter { get; set; }
        IEnumerable<_dict_orders_delivery> DictOrdersDelivery { get; set; }
        IEnumerable<_dict_rules> DictRules { get; set; }
        IEnumerable<_dict_shops> DictShops { get; set; }
        IEnumerable<_dict_status_compleints> DictStatusCompleints { get; set; }
        IEnumerable<_dict_status_orders> DictStatusOrders { get; set; }

        void ChangeCatalogName(int id, string newName);
    }
}
