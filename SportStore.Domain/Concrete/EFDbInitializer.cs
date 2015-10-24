using System.Data.Entity;
using SportStore.Domain.Entities;
using System.Collections.Generic;
using System;

namespace SportStore.Domain.Concrete
{
    /// <summary>
    /// Autor:  Mateusz Kniżewski
    /// Opis:   Klasa inicjalizująca bazę danych gdy jej nie ma
    /// Data:   17.10.15
    /// </summary>
    public class EFDbInitializer : CreateDatabaseIfNotExists<EFDbContext>
    {
        /// <summary>
        /// Ta metoda umożliwia nam podczas tworzenia bazy danych wypełnienie jej pierwszymi danymi oraz gdy model bazy się zmieni
        /// </summary>
        /// <param name="context">Zmienna bazowa</param>
        protected override void Seed(EFDbContext context)
        {
            //TODO: Zrobić sqlki z insertami do bazy, poniższe rozwiązanie jest tymczasowe!

            List<_dict_typeofnews_newsletter> dictType = new List<_dict_typeofnews_newsletter> 
            {
                new _dict_typeofnews_newsletter() { Name = "Piłka Nożna", InsertTime = DateTime.Now, UpdateTime = null },
                new _dict_typeofnews_newsletter() { Name = "Golf", InsertTime = DateTime.Now, UpdateTime = null },
                new _dict_typeofnews_newsletter() { Name = "Kocmołuchowo", InsertTime = DateTime.Now, UpdateTime  = null }
            };
            dictType.ForEach(x => context.DictNewsletter.Add(x));

            context.SaveChanges();
        }
    }
}
