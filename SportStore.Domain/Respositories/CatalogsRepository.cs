using SportStore.Domain.Abstract;
using SportStore.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportStore.Domain.Respositories
{
    /// <summary>
    /// Autor:  Mateusz Kniżewski
    /// Opis:   Klasa logiki bazodanowej katalogów produktów
    /// Data:   15.11.15
    /// </summary>
    public class CatalogsRepository : ICatalogsRepository
    {
        private EFDbContext _context = new EFDbContext();

        IEnumerable<Entities._dict_catalogs> ICatalogsRepository.Catalogs
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

        void ICatalogsRepository.Add(Entities._dict_catalogs catalog)
        {
            _context.DictCatalogs.Add(catalog);
            _context.SaveChanges();
        }

        void ICatalogsRepository.Edit(Entities._dict_catalogs newCatalog)
        {
            throw new NotImplementedException();
        }

        void ICatalogsRepository.Delete(int id)
        {
            var rowToDelete = _context.DictCatalogs.Select(x => x).Where(x => x.Id == id).FirstOrDefault();
            _context.DictCatalogs.Remove(rowToDelete);
            _context.SaveChanges();
        }

        IEnumerable<Entities.items> ICatalogsRepository.Items
        {
            get
            {
                return _context.Items;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        IEnumerable<Entities.items_picutures> ICatalogsRepository.ItemsPicture
        {
            get
            {
                return _context.ItemsPictures;
            }
            set
            {
                throw new NotImplementedException();
            }
        }


        IEnumerable<Entities.items_opinions> ICatalogsRepository.ItemsOpinions
        {
            get
            {
                return _context.ItemsOpinions;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        IEnumerable<Entities.items_quantity> ICatalogsRepository.ItemsQuantity
        {
            get
            {
                return _context.ItemsQuantity;
            }
            set
            {
                throw new NotImplementedException();
            }
        }


        IEnumerable<Entities._dict_description_items> ICatalogsRepository.ItemsDescriptions
        {
            get
            {
                return _context.DictDescriptionItems;
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
