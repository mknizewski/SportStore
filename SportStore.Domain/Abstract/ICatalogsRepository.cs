using SportStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportStore.Domain.Abstract
{
    /// <summary>
    /// Autor:  Mateusz Kniżewski
    /// Opis:   Interfejs repozytorium katalogów produktów w serwisie SportStore
    /// Data:   15.11.15
    /// </summary>
    public interface ICatalogsRepository
    {
        IEnumerable<_dict_catalogs> Catalogs { get; set; }
        IEnumerable<items> Items { get; set; }
        void Add(_dict_catalogs catalog);
        void Edit(_dict_catalogs newCatalog);
        void Delete(int id);
    }
}
