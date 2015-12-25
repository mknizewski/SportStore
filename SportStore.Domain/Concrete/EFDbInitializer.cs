using SportStore.Domain.Entities;
using SportStore.Domain.SqlFiles;
using System;
using System.Data.Entity;
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

            path = tablePath[0] + @"/SportStore.Domain/SqlFiles/Pictures";
            var imageFiles = Directory.GetFiles(path, "*.jpg");

            int iterator = 0;
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    var image = new items_picutures
                    {
                        Id_Item = (i + 1),
                        PictureData = HelperClass.Img2Byte(imageFiles[iterator]),
                        PictureMimeType = "picture/jpeg"
                    };

                    iterator++;
                    context.ItemsPictures.Add(image);
                }
            }

            context.SaveChanges();
        }
    }
}