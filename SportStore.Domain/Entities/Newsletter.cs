using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportStore.Domain.Entities
{
    /// <summary>
    /// Autor:  Mateusz Kniżewski
    /// Opis:   Klasa tabeli Newsletter
    /// Data:   17.10.15 
    /// </summary>
    public class Newsletter
    {
        public int Id { get; set; }
        public string email { get; set; }
        [Key, ForeignKey("TypeOfNews")]
        public int TypeOfNewsId { get; set; }
        public DateTime InsertTime { get; set; }

        public virtual _dict_newsletter TypeOfNews { get; set; }
    }
}
