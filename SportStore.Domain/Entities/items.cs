using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportStore.Domain.Entities
{
    /// <summary>
    /// Autor:  Mateusz Kniżewski
    /// Opis:   Tabela przechowująca produkty sklepu SportStore
    /// Data:   31.10.15
    /// </summary>
    public class items
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [Key, ForeignKey("Category")]
        public int Id_Category { get; set; }

        [Key, ForeignKey("Description")]
        public int Id_Description { get; set; }

        public decimal Price { get; set; }

        public virtual _dict_catalogs Category { get; set; }
        public virtual _dict_description_items Description { get; set; }
    }
}