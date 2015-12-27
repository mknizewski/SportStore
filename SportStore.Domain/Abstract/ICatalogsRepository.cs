using SportStore.Domain.Entities;
using System.Collections.Generic;

namespace SportStore.Domain.Abstract
{
    /// <summary>
    /// Autor:  Mateusz Kniżewski
    /// Opis:   Interfejs repozytorium katalogów produktów w serwisie SportStore
    /// Data:   15.11.15
    /// </summary>
    public interface ICatalogsRepository
    {
        //Pobieranie tabel z repozytorium
        IEnumerable<_dict_catalogs> Catalogs { get; set; }

        IEnumerable<items> Items { get; set; }
        IEnumerable<items_picutures> ItemsPicture { get; set; }
        IEnumerable<items_opinions> ItemsOpinions { get; set; }
        IEnumerable<items_quantity> ItemsQuantity { get; set; }
        IEnumerable<_dict_description_items> ItemsDescriptions { get; set; }
        IEnumerable<_dict_items_details> ItemsDetails { get; set; }

        //CRUD katalogowy
        void AddCatalog(_dict_catalogs catalog);

        void EditCatalog(_dict_catalogs newCatalog);

        void DeleteCatalog(int id);

        //CRUD opinii
        void AddOpinion(items_opinions opinion);

        void EditOpinion(items_opinions newOpinion);

        void DeleteOpinion(int id);
    }
}