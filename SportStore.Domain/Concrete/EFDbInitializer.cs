using System.Data.Entity;
using SportStore.Domain.Entities;
using System.Collections.Generic;
using System;
using System.IO;

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
        /// Dane inicializujące podczas tworzenia bazy danych
        /// </summary>
        /// <param name="context">Zmienna bazowa</param>
        protected override void Seed(EFDbContext context)
        {
            var tablePath = AppDomain.CurrentDomain.BaseDirectory.Split(new string[] { "SportStore.Web" }, StringSplitOptions.RemoveEmptyEntries);
            string path = tablePath[0] + @"/SportStore.Domain/SqlFiles/Initialization";

            var sqlFiles = Directory.GetFiles(path, "*.sql");
            foreach (var file in sqlFiles)
                context.Database.ExecuteSqlCommand(File.ReadAllText(file));

            context.SaveChanges();
        }
    }
}
