using SportStore.Domain.Abstract;
using SportStore.Domain.Concrete;
using SportStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace SportStore.Domain.Respositories
{
    public class DictionaryRepository : IDictionaryRepository
    {
        private EFDbContext _context = new EFDbContext();

        IEnumerable<_dict_catalogs> IDictionaryRepository.DictCatalogs
        {
            get
            {
                return _context.DictCatalogs;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        IEnumerable<_dict_cities> IDictionaryRepository.DictCities
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        IEnumerable<_dict_description_items> IDictionaryRepository.DictDescriptionItems
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        IEnumerable<_dict_items_details> IDictionaryRepository.DictItemsDetails
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        IEnumerable<_dict_newsletter> IDictionaryRepository.DictNewsletter
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        IEnumerable<_dict_orders_delivery> IDictionaryRepository.DictOrdersDelivery
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        IEnumerable<_dict_rules> IDictionaryRepository.DictRules
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        IEnumerable<_dict_shops> IDictionaryRepository.DictShops
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        IEnumerable<_dict_status_compleints> IDictionaryRepository.DictStatusCompleints
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        IEnumerable<_dict_status_orders> IDictionaryRepository.DictStatusOrders
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        void IDictionaryRepository.AddCatalog(string catalog)
        {
            var catalogToDb = new _dict_catalogs
            {
                Name = catalog,
                InsertTime = DateTime.Now
            };

            _context.DictCatalogs.Add(catalogToDb);
            _context.SaveChanges();
        }

        void IDictionaryRepository.ChangeCatalogName(int id, string newName)
        {
            var item = _context.DictCatalogs.Find(id);

            item.Name = newName;
            item.UpdateTime = DateTime.Now;

            _context.SaveChanges();
        }

        bool IDictionaryRepository.DeleteCatalog(int id)
        {
            var catalog = _context.DictCatalogs.Find(id);
            var item = _context.Items
                .Where(x => x.Id_Category == id)
                .ToList();

            if (item.Count == 0)
            {
                _context.DictCatalogs.Remove(catalog);
                _context.SaveChanges();

                return true;
            }

            return false;
        }
    }
}